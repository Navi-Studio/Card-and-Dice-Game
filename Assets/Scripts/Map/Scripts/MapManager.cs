using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

namespace Map
{
    public class MapManager : MonoBehaviour
    {
        public MapConfig config;
        public MapView view;

        public Map CurrentMap { get; private set; }

        private void Start()
        {
            // playerprefs 玩家数据简单缓存
            //if (PlayerPrefs.HasKey("Map"))  // 如果有之前缓存的地图数据 SaveMap()
            //{
            //    var mapJson = PlayerPrefs.GetString("Map");
            //    var map = JsonConvert.DeserializeObject<Map>(mapJson);
            //    // using this instead of .Contains()
            //    if (map.path.Any(p => p.Equals(map.GetBossNode().point)))
            //    {
            //        // payer has already reached the boss, generate a new map
            //        GenerateNewMap();
            //    }
            //    else
            //    {
            //        CurrentMap = map;
            //        // player has not reached the boss yet, load the current map
            //        view.ShowMap(map);
            //    }
            //}
            //else
            //{
            //    GenerateNewMap();
            //}
            //string filePath = "D/GameData.json";
            //System.IO.File.WriteAllText(filePath, CurrentMap.ToJson());
            // create your map
            if (PlayerPrefs.HasKey("Map"))  // 如果有之前缓存的地图数据 SaveMap()
            {
                var mapJson = PlayerPrefs.GetString("Map");
                var map = JsonConvert.DeserializeObject<Map>(mapJson);
                // using this instead of .Contains()
                CurrentMap = map;
                // player has not reached the boss yet, load the current map
                view.ShowMap(map);
                //if (mapManager.CurrentMap.path.Count > 0)
                //{
                //    var currentPoint = mapManager.CurrentMap.path[mapManager.CurrentMap.path.Count - 1];
                //    var currentNode = MapNodes.FirstOrDefault(node => node.Node.point == currentPoint);
                //    currentPosition = currentNode.transform.position;
                //}

                Transform currentNode = null;
                if (CurrentMap.path.Count > 0)
                {
                    var currentPoint = CurrentMap.path[CurrentMap.path.Count - 1];

                    currentNode = view.MapNodes.FirstOrDefault(node => node.Node.point.x == currentPoint.x && node.Node.point.y == currentPoint.y).transform;

                }
                //else
                //{
                //    view.MapNodes[0].OnPreCall();
                //}
                view.SetPlayerPosition(currentNode);
            }
            else
            {
                GenerateMyMap();
            }
        }

        // 点击按钮，生成新地图
        public void GenerateNewMap()
        {
            var map = MapGenerator.GetMap(config);
            CurrentMap = map;
            Debug.Log(map.ToJson());
            view.ShowMap(map);
        }

        // 生成指定地图
        public void GenerateMyMap()
        {
            var map = MyMapGenerator.GetMap(config);
            CurrentMap = map;
            Debug.Log(map.ToJson());
            view.ShowMap(map);

            // view.MapNodes[0].OnPreCall();
        }

        public void SaveMap()
        {
            if (CurrentMap == null) return;

            var json = JsonConvert.SerializeObject(CurrentMap, Formatting.Indented,
                new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            PlayerPrefs.SetString("Map", json);
            PlayerPrefs.Save();


        }

        private void OnApplicationQuit()
        {
            SaveMap();
        }
    }
}
