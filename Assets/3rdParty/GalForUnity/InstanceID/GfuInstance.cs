//======================================================================
//
//       CopyRight 2019-2021 © MUXI Game Studio 
//       . All Rights Reserved 
//
//        FileName :  GfuInstance.cs
//
//        Created by 半世癫(Roc) at 2021-01-15 21:27:36
//
//======================================================================

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Compilation;
using UnityEditor.SceneManagement;
#endif
using System;
using System.Collections.Generic;
using GalForUnity.System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace GalForUnity.InstanceID{
    [DisallowMultipleComponent]
    public class GfuInstance : MonoBehaviour{
        [SerializeField] public long instanceID = -1;
        private long InstanceID => this.GetInstanceID();

        private long MemoryInstanceID{
            get{
                if (!memory.ContainsKey(InstanceID)) return -1;
                return memory[InstanceID];
            }
            set => memory[InstanceID] = value;
        }

        private long _instanceID;


        public static Dictionary<long, GfuInstance> GfuInstances = new Dictionary<long, GfuInstance>();
        public static readonly Dictionary<long, long> memory = new Dictionary<long, long>();

        private void Reset(){
            // if (instanceID == -1){
            //     Init(); //唯一的InstanceID
            // }
        }

        private void OnValidate(){
#if UNITY_EDITOR
            if (!this) return;

            hideFlags = HideFlags.NotEditable;

            if (MemoryInstanceID != -1){
                instanceID = MemoryInstanceID;
            }

            if (InstanceID < 0 && GameSystem.GetInstance().currentInstanceIDStorage.HasInstanceID(instanceID) && _instanceID == 0){ //如果硬盘中中存在相同ID，而且自身ID是负的说明这是预制体的拷贝
                if (MemoryInstanceID == -1){
                    if (transform.GetComponentInChildren<SafeInstanceID>().name == "" + instanceID){
                        MemoryInstanceID = instanceID = Init();
                    }
                }
            }

            if (_instanceID == 0 && MemoryInstanceID == -1 && GfuInstances.ContainsKey(instanceID)){
                if (transform.GetComponentInChildren<SafeInstanceID>().name == "" + instanceID){
                    MemoryInstanceID = instanceID = Init();
                }
            }


            if (instanceID == -1){
                MemoryInstanceID = instanceID = Init();
            }

            if (MemoryInstanceID == -1){ //如果内存ID是空的则赋值
                MemoryInstanceID = instanceID;
            }

            SafeInstanceID();

            _instanceID = instanceID;
            if (!GfuInstances.ContainsKey(instanceID)) GfuInstances.Add(instanceID, this); //添加入字典，保证加载速度
#endif
        }

        public long Init(){
            MemoryInstanceID = instanceID = this.CreateInstanceID();
            return instanceID;
        }


        public void SafeInstanceID(){
#if UNITY_EDITOR
            var componentInChildren = transform.GetComponentInChildren<SafeInstanceID>();
            if (!componentInChildren){
                if (!EditorUtility.IsPersistent(gameObject)){
                    GfuRunOnMono.Update(() => {
                        var safeInstanceIDObject = new GameObject {
                            name = instanceID + ""
                        };
                        safeInstanceIDObject.transform.parent = transform;
                        safeInstanceIDObject.transform.SetAsFirstSibling();
                        safeInstanceIDObject.gameObject.hideFlags = HideFlags.HideInHierarchy;
                        safeInstanceIDObject.gameObject.AddComponent<SafeInstanceID>();
                    });
                }
            } else{
                var o = componentInChildren.gameObject;
                o.hideFlags = HideFlags.HideInHierarchy;
                o.name = "" + instanceID;
            }
#endif
        }

        public static long CreateInstanceID(){
            return BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0); //保存节点的InstanceID此ID供节点系统查找唯一节点
        }

        public static T ToGfuInstance<T>(T monoBbj) where T : Object{
            if (monoBbj is GameObject gameObject){
                return CreateGfuInstance(gameObject) as T;
            }
            if (monoBbj is MonoBehaviour monoBehaviour){
                return CreateGfuInstance(monoBehaviour.gameObject) as T;
            }
            return monoBbj;
        }
        

        public static GameObject CreateGfuInstance(GameObject monoBbj){
            if (monoBbj.TryGetComponent(out GfuInstance gfuInstances)){
                return monoBbj;
            } else{
                return monoBbj.AddComponent<GfuInstance>().gameObject;
            }
        }
        

        public static T FindObjectsWithGfuInstanceID<T>(long gfuInstanceID) where T : Object{ return FindObjectsWithGfuInstanceID(gfuInstanceID, typeof(T)) as T; }

        public static Object FindObjectsWithGfuInstanceID(long gfuInstanceID, Type type){
            if (GfuInstances != null && GfuInstances.ContainsKey(gfuInstanceID)) return GfuInstances[gfuInstanceID]?.GetComponent(type); //优先到字典中寻找对象而非去遍历
            var currentInstanceIDStorage = GameSystem.GetInstance().currentInstanceIDStorage;
            foreach (var gfuInstance in ObjectOfType<GfuInstance>()){ //遍历内存中的对象
                if (gfuInstanceID == gfuInstance.instanceID){
                    GfuInstances?.Add(gfuInstanceID, gfuInstance);
                    return gfuInstance.GetComponent(type);
                }
            }

            if (currentInstanceIDStorage) return InstanceIDStorageLoadTool.Load(gfuInstanceID); //如果内存中没有找到对象，通过InstanceID储存器加载，
            return null;
        }

        public static T FindAllWithGfuInstanceID<T>(long gfuInstanceID) where T : Object{ return FindAllWithGfuInstanceID(gfuInstanceID, typeof(T)) as T; }

        public static Object FindAllWithGfuInstanceID(long gfuInstanceID, Type type){
            if (GfuInstances != null && GfuInstances.ContainsKey(gfuInstanceID)) return GfuInstances[gfuInstanceID]?.GetComponent(type); //优先到字典中寻找对象而非去遍历
            var currentInstanceIDStorage = GameSystem.GetInstance().currentInstanceIDStorage;
            Object loadedObject = null;
            if (currentInstanceIDStorage) loadedObject = InstanceIDStorageLoadTool.Load(gfuInstanceID); //如果内存字典找不到对象，则去InstanceID储存器中去加载
            if (loadedObject) return loadedObject;
            foreach (var gfuInstance in AllOfType<GfuInstance>()){ //如果InstanceID储存器不存在遍历Resource及场景中全部对象
                if (gfuInstanceID == gfuInstance.instanceID){
                    if (!GfuInstances.ContainsKey(gfuInstanceID)) GfuInstances.Add(gfuInstanceID, gfuInstance);
                    return gfuInstance.GetComponent(type);
                }
            }

            return null;
        }

        private void OnDestroy(){ GfuInstances.Remove(instanceID); }

        private static T[] ObjectOfType<T>() where T : Object{ return FindObjectsOfType<T>(); }
        private static T[] AllOfType<T>() where T : Object{ return Resources.FindObjectsOfTypeAll<T>(); }

#if UNITY_EDITOR

        private static void Clear(){
            GfuInstances?.Clear();
            GfuInstances = new Dictionary<long, GfuInstance>();
        }

        private static void SceneOpening(string path, OpenSceneMode openSceneMode){ Clear(); }

        [UnityEditor.Callbacks.DidReloadScripts(0)]
        static void OnScriptReload(){
            // Clear();
            // Debug.Log("reload");
        }

        private static void SceneClosing(Scene scene, bool removingScene){
            // EditorSceneManager.sceneOpening -= SceneOpening;
            // EditorSceneManager.sceneClosing -= SceneClosing;
            Clear();
            // PrefabUtility.prefabInstanceUpdated -= PrefabInstanceUpdated;
        }

        [InitializeOnLoadMethod]
        static void StartInitializeOnLoadMethod(){
            EditorSceneManager.sceneClosing += SceneClosing;
            EditorSceneManager.sceneOpening += SceneOpening;
            EditorApplication.playModeStateChanged += (x) => {
                if (x == PlayModeStateChange.ExitingEditMode) Clear();
                if (x == PlayModeStateChange.ExitingPlayMode) Clear();
            };
            CompilationPipeline.assemblyCompilationFinished += Clear;
        }

        private static void Clear(string arg1, CompilerMessage[] arg2){ Clear(); }


#endif
    }
}