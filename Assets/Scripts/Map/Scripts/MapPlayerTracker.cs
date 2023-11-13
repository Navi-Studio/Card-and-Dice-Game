using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Map
{
    public class MapPlayerTracker : MonoBehaviour
    {
        public GameObject Treasure;
        public GameObject Store;
        public GameObject Rest;

        public bool lockAfterSelecting = false;
        public float enterNodeDelay = 1f;
        public MapManager mapManager;
        public MapView view;

        // 单例
        public static MapPlayerTracker Instance;

        public bool Locked { get; set; }

        private void Awake()
        {
            Instance = this;
        }

        public void SelectNode(MapNode mapNode)
        {
            if (Locked) return;

            // Debug.Log("Selected node: " + mapNode.Node.point);
            //m_logNums = mapNode.Node.point.y;

            if (mapManager.CurrentMap.path.Count == 0)
            {
                // player has not selected the node yet, he can select any of the nodes with y = 0
                if (mapNode.Node.point.y == 0)
                    SendPlayerToNode(mapNode);
                else
                    PlayWarningThatNodeCannotBeAccessed();
            }
            else
            {
                var currentPoint = mapManager.CurrentMap.path[mapManager.CurrentMap.path.Count - 1];
                var currentNode = mapManager.CurrentMap.GetNode(currentPoint);

                if (currentNode != null && currentNode.outgoing.Any(point => point.Equals(mapNode.Node.point)))
                    SendPlayerToNode(mapNode);
                else
                    PlayWarningThatNodeCannotBeAccessed();
            }
        }

        private void SendPlayerToNode(MapNode mapNode)
        {
            // move player
            //player.transform.DOMove(mapNode.transform.localPosition, enterNodeDelay);
            view.SetPlayerPosition(mapNode);

            Locked = lockAfterSelecting;
            mapManager.CurrentMap.path.Add(mapNode.Node.point);
            mapManager.SaveMap();
            view.SetAttainableNodes();
            view.SetLineColors();
            mapNode.ShowSwirlAnimation();
            // 动画引擎
            DOTween.Sequence().AppendInterval(enterNodeDelay).OnComplete(() => EnterNode(mapNode, Treasure, Store, Rest));
        }

        private static void EnterNode(MapNode mapNode, GameObject Treasure, GameObject Store, GameObject Rest)
        {
            
            // we have access to blueprint name here as well
            Debug.Log("Entering node: " + mapNode.Node.blueprintName + " of type: " + mapNode.Node.nodeType);
            // load appropriate scene with context based on nodeType:
            // or show appropriate GUI over the map: 
            // if you choose to show GUI in some of these cases, do not forget to set "Locked" in MapPlayerTracker back to false
            switch (mapNode.Node.nodeType)
            {
                case NodeType.MinorEnemy:
                    Debug.Log("battle event");
                    break;
                case NodeType.EliteEnemy:
                    Debug.Log("battle event");
                    break;
                case NodeType.RestSite:
                    Debug.Log("dialog event");
                    break;
                case NodeType.Treasure:
                    Debug.Log("dialog event");
                    break;
                case NodeType.Store:
                    Debug.Log("dialog event");
                    break;
                case NodeType.Boss:
                    Debug.Log("battle event");
                    break;
                case NodeType.Mystery:
                    Debug.Log("dialog event");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (mapNode.Node.sceneName != "")
            {
                if (mapNode.Node.sceneName == "Treasure")
                {
                    bool state = Treasure.activeSelf;
                    Treasure.SetActive(!state);
                }
                else if(mapNode.Node.sceneName == "Store")
                {
                    bool state = Store.activeSelf;
                    Store.SetActive(!state);
                }
                else if (mapNode.Node.sceneName == "Rest Site")
                {
                    bool state = Rest.activeSelf;
                    Rest.SetActive(!state);
                }
                else
                {
                    SceneManager.LoadScene(mapNode.Node.sceneName);
                }
            }
        }

        private void PlayWarningThatNodeCannotBeAccessed()
        {
            Debug.Log("Selected node cannot be accessed");
        }
    }
}