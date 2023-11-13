using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Map
{
    public static class MyMapGenerator
    {
        private static MapConfig config;
        //
        private static int confLayersCount = 5 ;
        private static float confLayerNodesApartDistance = 1 ;
        private static int confGridWidth = 4 ;
        private static int configNumOfStartingNodes = 3 ;
        private static int configNumOfPreBossNodes = 3 ;
        private static string confName = "DefaultMapConfig";//"Angel Dice"; (Map.MapConfig)

        private static readonly List<NodeType> RandomNodes = new List<NodeType>
        {NodeType.Mystery, NodeType.Store, NodeType.Treasure, NodeType.MinorEnemy, NodeType.RestSite};

        private static List<float> layerDistances;
        private static List<List<Point>> paths;// 玩家走过的路径还是地图可选的路径,高亮轨迹
        // ALL nodes by layer:
        private static readonly List<List<Node>> nodes = new List<List<Node>>();

        public static Map GetMap(MapConfig conf)
        {
            if (conf == null)
            {
                Debug.LogWarning("Config was null in MapGenerator.Generate()");
                return null;
            }

            config = conf;
            nodes.Clear();
            // 每个layer与前面的相对距离
            GenerateLayerDistances();
            // 先在每个layer上摆好node position
            //for (var i = 0; i < confLayersCount; i++)
            //    PlaceLayer(i);
            //MyPlaceLayer();
            //FirstMap();
            //FirstConnections();l
            DemoMap();
            DemoConnections();

            //GeneratePaths();
            // 在进行偏移
            //RandomizeNodePositions();

            //SetUpConnections();

            //RemoveCrossConnections();
            //MyConnections();

            //var player = new Node(NodeType.MinorEnemy, "Minor Enemy", new Point(1, 3));
            //var boss = new Node(NodeType.Boss, "Skeleton Boss", new Point(6, 9));
            //player.AddOutgoing(boss.point);
            //boss.AddIncoming(player.point);
            //player.position = new Vector2(5, 5);
            //boss.position = new Vector2(15, 15);
            //nodes.Clear();
            //var layer1 = new List<Node>();
            //var layer2 = new List<Node>();
            //layer1.Add(player);
            //layer1.Add(boss);
            //nodes.Add(layer1);
            ////nodes.Add(layer2);
            //var nodesList = nodes[0];

            // select all the nodes with connections:
            var nodesList = nodes.SelectMany(n => n).Where(n => n.incoming.Count > 0 || n.outgoing.Count > 0).ToList();

            // pick a random name of the boss level for this map:
            //var bossNodeName = config.nodeBlueprints.Where(b => b.nodeType == NodeType.Boss).ToList().Random().name;
            var bossNodeName = "Spider Boss";
            return new Map(confName, bossNodeName, nodesList, new List<Point>());
        }

        private static void GenerateLayerDistances()
        {
            layerDistances = new List<float>();
            for (var i = 0; i < confLayersCount; i++)
                layerDistances.Add(2f);
        }

        private static float GetDistanceToLayer(int layerIndex)
        {
            if (layerIndex < 0 || layerIndex > layerDistances.Count) return 0f;

            return layerDistances.Take(layerIndex).Sum();
        }

        private static void MyPlaceLayer()
        {
            var offset = confLayerNodesApartDistance * confGridWidth / 2f;
            // layer 0
            var nodesOnThisLayer0 = new List<Node>();
            var node = new Node(NodeType.Mystery, "Mystery", new Point(2, 0))
            {
                //position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(0))
                position = new Vector2(-2.07f, -0.8f)
            };
            nodesOnThisLayer0.Add(node);
            nodes.Add(nodesOnThisLayer0);
            // layer 1
            var nodesOnThisLayer1 = new List<Node>();
            node = new Node(NodeType.MinorEnemy, "Minor Enemy", new Point(0, 1))
            {
                position = new Vector2(-offset + 0 * confLayerNodesApartDistance, GetDistanceToLayer(1))
            };
            nodesOnThisLayer1.Add(node);
            node = new Node(NodeType.Mystery, "Mystery", new Point(4, 1))
            {
                position = new Vector2(-offset + 4 * confLayerNodesApartDistance, GetDistanceToLayer(1))
            };
            nodesOnThisLayer1.Add(node);
            nodes.Add(nodesOnThisLayer1);
            // layer 2
            var nodesOnThisLayer2 = new List<Node>();
            node = new Node(NodeType.Treasure, "Treasure", new Point(2, 2))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(2))
            };
            nodesOnThisLayer2.Add(node);
            nodes.Add(nodesOnThisLayer2);
            // layer 3
            var nodesOnThisLayer3 = new List<Node>();
            node = new Node(NodeType.Store, "Store", new Point(0, 3))
            {
                position = new Vector2(-offset + 0 * confLayerNodesApartDistance, GetDistanceToLayer(3))
            };
            nodesOnThisLayer3.Add(node);
            node = new Node(NodeType.MinorEnemy, "Minor Enemy", new Point(4, 3))
            {
                position = new Vector2(-offset + 4 * confLayerNodesApartDistance, GetDistanceToLayer(3))
            };
            nodesOnThisLayer3.Add(node);
            nodes.Add(nodesOnThisLayer3);
            // layer 4
            var nodesOnThisLayer4 = new List<Node>();
            node = new Node(NodeType.EliteEnemy, "Elite Enemy", new Point(2, 4))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(4))
            };
            nodesOnThisLayer4.Add(node);
            nodes.Add(nodesOnThisLayer4);
            // layer 5
            var nodesOnThisLayer5 = new List<Node>();
            node = new Node(NodeType.Mystery, "Mystery", new Point(0, 5))
            {
                position = new Vector2(-offset + 0 * confLayerNodesApartDistance, GetDistanceToLayer(5))
            };
            nodesOnThisLayer5.Add(node);
            node = new Node(NodeType.Treasure, "Treasure", new Point(4, 5))
            {
                position = new Vector2(-offset + 4 * confLayerNodesApartDistance, GetDistanceToLayer(5))
            };
            nodesOnThisLayer5.Add(node);
            nodes.Add(nodesOnThisLayer5);
            // layer 6
            var nodesOnThisLayer6 = new List<Node>();
            node = new Node(NodeType.Boss, "Spider Boss", new Point(2, 6))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(6))
            };
            nodesOnThisLayer6.Add(node);
            nodes.Add(nodesOnThisLayer6);
        }

        private static void FirstMap()
        {
            var offset = confLayerNodesApartDistance * confGridWidth / 2f;
            // layer 0
            var nodesOnThisLayer0 = new List<Node>();
            var node = new Node(NodeType.RestSite, "Rest Site", new Point(2, 0))
            {
                position = new Vector2(0, GetDistanceToLayer(0)),
                sceneName = "C1S1"
            };
            nodesOnThisLayer0.Add(node);
            nodes.Add(nodesOnThisLayer0);
            // layer 1
            var nodesOnThisLayer1 = new List<Node>();
            node = new Node(NodeType.MinorEnemy, "Minor Enemy", new Point(0, 1))
            {
                position = new Vector2(-offset + 0 * confLayerNodesApartDistance, GetDistanceToLayer(1)),
                sceneName = "BattleScene"
            };
            nodesOnThisLayer1.Add(node);
            node = new Node(NodeType.Treasure, "Treasure", new Point(2, 1))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(1) + 1)
            };
            nodesOnThisLayer1.Add(node);
            node = new Node(NodeType.Mystery, "Mystery", new Point(4, 1))
            {
                position = new Vector2(-offset + 4 * confLayerNodesApartDistance, GetDistanceToLayer(1))
            };
            nodesOnThisLayer1.Add(node);
            nodes.Add(nodesOnThisLayer1);
            // layer 2
            var nodesOnThisLayer2 = new List<Node>();
            node = new Node(NodeType.Store, "Store", new Point(0, 2))
            {
                position = new Vector2(-offset + 0 * confLayerNodesApartDistance, GetDistanceToLayer(2)),
                sceneName = "C1S2"
            };
            nodesOnThisLayer2.Add(node);
            node = new Node(NodeType.RestSite, "Rest Site", new Point(4, 2))
            {
                position = new Vector2(-offset + 4 * confLayerNodesApartDistance, GetDistanceToLayer(2))
            };
            nodesOnThisLayer2.Add(node);
            nodes.Add(nodesOnThisLayer2);
            // layer 3
            var nodesOnThisLayer3 = new List<Node>();
            node = new Node(NodeType.MinorEnemy, "Minor Enemy", new Point(2, 3))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(3)),
                sceneName = "BattleScene"
            };
            nodesOnThisLayer3.Add(node);
            nodes.Add(nodesOnThisLayer3);
            // layer 4
            var nodesOnThisLayer4 = new List<Node>();
            node = new Node(NodeType.RestSite, "Rest Site", new Point(2, 4))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(4)),
                sceneName = "C1S3"
            };
            nodesOnThisLayer4.Add(node);
            nodes.Add(nodesOnThisLayer4);
            // layer 5
            var nodesOnThisLayer5 = new List<Node>();
            node = new Node(NodeType.Treasure, "Treasure", new Point(0, 5))
            {
                position = new Vector2(-offset + 0 * confLayerNodesApartDistance, GetDistanceToLayer(5))
            };
            nodesOnThisLayer5.Add(node);
            node = new Node(NodeType.Mystery, "Mystery", new Point(2, 5))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(5) + 1)
            };
            nodesOnThisLayer5.Add(node);
            node = new Node(NodeType.Mystery, "Mystery", new Point(4, 5))
            {
                position = new Vector2(-offset + 4 * confLayerNodesApartDistance, GetDistanceToLayer(5) + 1)
            };
            nodesOnThisLayer5.Add(node);
            nodes.Add(nodesOnThisLayer5);
            // layer 6
            var nodesOnThisLayer6 = new List<Node>();
            node = new Node(NodeType.MinorEnemy, "Minor Enemy", new Point(0, 6))
            {
                position = new Vector2(-offset + 0 * confLayerNodesApartDistance, GetDistanceToLayer(6))
            };
            nodesOnThisLayer6.Add(node);
            nodes.Add(nodesOnThisLayer6);
            // layer 7
            var nodesOnThisLayer7 = new List<Node>();
            node = new Node(NodeType.EliteEnemy, "Elite Enemy", new Point(2, 7))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(7))
            };
            nodesOnThisLayer7.Add(node);
            nodes.Add(nodesOnThisLayer7);
            // layer 8
            var nodesOnThisLayer8 = new List<Node>();
            node = new Node(NodeType.RestSite, "Rest Site", new Point(0, 8))
            {
                position = new Vector2(-offset + 0 * confLayerNodesApartDistance, GetDistanceToLayer(8))
            };
            nodesOnThisLayer8.Add(node);
            node = new Node(NodeType.MinorEnemy, "Minor Enemy", new Point(2, 8))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(8))
            };
            nodesOnThisLayer8.Add(node);
            node = new Node(NodeType.Treasure, "Treasure", new Point(4, 8))
            {
                position = new Vector2(-offset + 4 * confLayerNodesApartDistance, GetDistanceToLayer(8))
            };
            nodesOnThisLayer8.Add(node);
            nodes.Add(nodesOnThisLayer8);
            // layer 9
            var nodesOnThisLayer9 = new List<Node>();
            node = new Node(NodeType.Boss, "Spider Boss", new Point(2, 9))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(9))
            };
            nodesOnThisLayer9.Add(node);
            nodes.Add(nodesOnThisLayer9);
        }

        private static void DemoMap()
        {
            var offset = confLayerNodesApartDistance * confGridWidth / 2f;
            // layer 0
            var nodesOnThisLayer0 = new List<Node>();
            var node = new Node(NodeType.MinorEnemy, "Minor Enemy", new Point(2, 0))
            {
                position = new Vector2(0, GetDistanceToLayer(0)),
                sceneName = "C1B1"
            };
            nodesOnThisLayer0.Add(node);
            nodes.Add(nodesOnThisLayer0);
            // layer 1
            var nodesOnThisLayer1 = new List<Node>();
            node = new Node(NodeType.Treasure, "Treasure", new Point(0, 1))
            {
                position = new Vector2(-offset + 0 * confLayerNodesApartDistance, GetDistanceToLayer(1)),
                sceneName = "Treasure"
            };
            nodesOnThisLayer1.Add(node);
            node = new Node(NodeType.Store, "Store", new Point(2, 1))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(1)),
                sceneName = "Store"
            };
            nodesOnThisLayer1.Add(node);
            node = new Node(NodeType.RestSite, "Rest Site", new Point(4, 1))
            {
                position = new Vector2(-offset + 4 * confLayerNodesApartDistance, GetDistanceToLayer(1)),
                sceneName = "Rest Site"
            };
            nodesOnThisLayer1.Add(node);
            nodes.Add(nodesOnThisLayer1);
            // layer 2
            var nodesOnThisLayer2 = new List<Node>();
            node = new Node(NodeType.EliteEnemy, "Elite Enemy", new Point(2, 2))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(2)),
                sceneName = "C1B2"
            };
            nodesOnThisLayer2.Add(node);
            nodes.Add(nodesOnThisLayer2);
            // layer 3
            var nodesOnThisLayer3 = new List<Node>();
            node = new Node(NodeType.Treasure, "Treasure", new Point(0, 3))
            {
                position = new Vector2(-offset + 0 * confLayerNodesApartDistance, GetDistanceToLayer(3)),
                sceneName = "Treasure"
            };
            nodesOnThisLayer3.Add(node);
            node = new Node(NodeType.Store, "Store", new Point(2, 3))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(3)),
                sceneName = "Store"
            };
            nodesOnThisLayer3.Add(node);
            node = new Node(NodeType.RestSite, "Rest Site", new Point(4, 3))
            {
                position = new Vector2(-offset + 4 * confLayerNodesApartDistance, GetDistanceToLayer(3)),
                sceneName = "Rest Site"
            };
            nodesOnThisLayer3.Add(node);
            nodes.Add(nodesOnThisLayer3);
            // layer 4
            var nodesOnThisLayer4 = new List<Node>();
            node = new Node(NodeType.Boss, "Spider Boss", new Point(2, 4))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(4)),
                sceneName = "C1B3"
            };
            nodesOnThisLayer4.Add(node);
            nodes.Add(nodesOnThisLayer4);
            // layer 5
            var nodesOnThisLayer5 = new List<Node>();
            node = new Node(NodeType.RestSite, "Rest Site", new Point(2, 5))
            {
                position = new Vector2(-offset + 2 * confLayerNodesApartDistance, GetDistanceToLayer(5)),
                sceneName = "GameStart"
            };
            nodesOnThisLayer5.Add(node);
            nodes.Add(nodesOnThisLayer5);
        }

        private static void RandomizeNodePositions()
        {
            for (var index = 0; index < nodes.Count; index++)
            {
                var list = nodes[index];
                var layer = config.layers[index];
                var distToNextLayer = index + 1 >= layerDistances.Count
                    ? 0f
                    : layerDistances[index + 1];
                var distToPreviousLayer = layerDistances[index];

                foreach (var node in list)
                {
                    var xRnd = Random.Range(-1f, 1f);
                    var yRnd = Random.Range(-1f, 1f);

                    var x = xRnd * layer.nodesApartDistance / 2f;
                    var y = yRnd < 0 ? distToPreviousLayer * yRnd / 2f : distToNextLayer * yRnd / 2f;

                    node.position += new Vector2(x, y) * layer.randomizePosition;
                }
            }
        }

        private static void SetUpConnections()
        {
            foreach (var path in paths)
            {
                for (var i = 0; i < path.Count - 1; ++i)
                {
                    var node = GetNode(path[i]);
                    var nextNode = GetNode(path[i + 1]);
                    node.AddOutgoing(nextNode.point);
                    nextNode.AddIncoming(node.point);
                }
            }
        }

        private static void RemoveCrossConnections()
        {
            for (var i = 0; i < config.GridWidth - 1; ++i)
                for (var j = 0; j < config.layers.Count - 1; ++j)
                {
                    var node = GetNode(new Point(i, j));
                    if (node == null || node.HasNoConnections()) continue;
                    var right = GetNode(new Point(i + 1, j));
                    if (right == null || right.HasNoConnections()) continue;
                    var top = GetNode(new Point(i, j + 1));
                    if (top == null || top.HasNoConnections()) continue;
                    var topRight = GetNode(new Point(i + 1, j + 1));
                    if (topRight == null || topRight.HasNoConnections()) continue;

                    // Debug.Log("Inspecting node for connections: " + node.point);
                    if (!node.outgoing.Any(element => element.Equals(topRight.point))) continue;
                    if (!right.outgoing.Any(element => element.Equals(top.point))) continue;

                    // Debug.Log("Found a cross node: " + node.point);

                    // we managed to find a cross node:
                    // 1) add direct connections:
                    node.AddOutgoing(top.point);
                    top.AddIncoming(node.point);

                    right.AddOutgoing(topRight.point);
                    topRight.AddIncoming(right.point);

                    var rnd = Random.Range(0f, 1f);
                    if (rnd < 0.2f)
                    {
                        // remove both cross connections:
                        // a) 
                        node.RemoveOutgoing(topRight.point);
                        topRight.RemoveIncoming(node.point);
                        // b) 
                        right.RemoveOutgoing(top.point);
                        top.RemoveIncoming(right.point);
                    }
                    else if (rnd < 0.6f)
                    {
                        // a) 
                        node.RemoveOutgoing(topRight.point);
                        topRight.RemoveIncoming(node.point);
                    }
                    else
                    {
                        // b) 
                        right.RemoveOutgoing(top.point);
                        top.RemoveIncoming(right.point);
                    }
                }
        }

        private static Node GetNode(Point p)
        {
            if (p.y >= nodes.Count) return null;
            if (p.x >= nodes[p.y].Count) return null;

            return nodes[p.y][p.x];
        }

        private static Point GetFinalNode()
        {
            var y = confLayersCount - 1;
            if (confGridWidth % 2 == 1)
                return new Point(confGridWidth / 2, y);

            return Random.Range(0, 2) == 0
                ? new Point(confGridWidth / 2, y)
                : new Point(confGridWidth / 2 - 1, y);
            // 从csv中得到boss位置
        }

        private static void GeneratePaths()
        {
            var finalNode = GetFinalNode();
            paths = new List<List<Point>>();
            var numOfStartingNodes = configNumOfStartingNodes;
            var numOfPreBossNodes = configNumOfPreBossNodes;

            var candidateXs = new List<int>();
            for (var i = 0; i < confGridWidth; i++)
                candidateXs.Add(i);
            // ////////
            // o ...
            // o ...
            // o ...
            // o ...
            // 
            // 
            candidateXs.Shuffle();
            var startingXs = candidateXs.Take(numOfStartingNodes);
            var startingPoints = (from x in startingXs select new Point(x, 0)).ToList();
            // ////////
            // ... o 
            // ... o  boss
            // ... o 
            // ... o 
            candidateXs.Shuffle();
            var preBossXs = candidateXs.Take(numOfPreBossNodes);
            var preBossPoints = (from x in preBossXs select new Point(x, finalNode.y - 1)).ToList();

            int numOfPaths = Mathf.Max(numOfStartingNodes, numOfPreBossNodes) + Mathf.Max(0, config.extraPaths);
            for (int i = 0; i < numOfPaths; ++i)
            {
                Point startNode = startingPoints[i % numOfStartingNodes];
                Point endNode = preBossPoints[i % numOfPreBossNodes];
                // 枚举所有起点终点
                var path = Path(startNode, endNode);
                path.Add(finalNode);
                paths.Add(path);
            }
        }

        // Generates a random path bottom up.
        private static List<Point> Path(Point fromPoint, Point toPoint)
        {
            int toRow = toPoint.y;
            int toCol = toPoint.x;

            int lastNodeCol = fromPoint.x;

            var path = new List<Point> { fromPoint };
            var candidateCols = new List<int>();
            for (int row = 1; row < toRow; ++row)
            {
                candidateCols.Clear();

                int verticalDistance = toRow - row;
                int horizontalDistance;

                int forwardCol = lastNodeCol;
                horizontalDistance = Mathf.Abs(toCol - forwardCol);
                if (horizontalDistance <= verticalDistance)
                    candidateCols.Add(lastNodeCol);

                int leftCol = lastNodeCol - 1;
                horizontalDistance = Mathf.Abs(toCol - leftCol);
                if (leftCol >= 0 && horizontalDistance <= verticalDistance)
                    candidateCols.Add(leftCol);

                int rightCol = lastNodeCol + 1;
                horizontalDistance = Mathf.Abs(toCol - rightCol);
                if (rightCol < config.GridWidth && horizontalDistance <= verticalDistance)
                    candidateCols.Add(rightCol);

                int RandomCandidateIndex = Random.Range(0, candidateCols.Count);
                int candidateCol = candidateCols[RandomCandidateIndex];
                var nextPoint = new Point(candidateCol, row);

                path.Add(nextPoint);

                lastNodeCol = candidateCol;
            }

            path.Add(toPoint);

            return path;
        }

        private static NodeType GetRandomNode()
        {
            return RandomNodes[Random.Range(0, RandomNodes.Count)];
        }
    
        private static void MyConnections()
        {
            nodes[0][0].AddOutgoing(nodes[1][0].point);
            nodes[0][0].AddOutgoing(nodes[1][1].point);
            nodes[0][0].AddOutgoing(nodes[2][0].point);
            nodes[1][0].AddIncoming(nodes[0][0].point);
            nodes[1][1].AddIncoming(nodes[0][0].point);
            nodes[2][0].AddIncoming(nodes[0][0].point);

            nodes[1][0].AddOutgoing(nodes[3][0].point);
            nodes[3][0].AddIncoming(nodes[1][0].point);

            nodes[1][1].AddOutgoing(nodes[3][1].point);
            nodes[3][1].AddIncoming(nodes[1][1].point);

            nodes[2][0].AddOutgoing(nodes[3][0].point);
            nodes[2][0].AddOutgoing(nodes[3][1].point);
            nodes[3][0].AddIncoming(nodes[2][0].point);
            nodes[3][1].AddIncoming(nodes[2][0].point);

            nodes[3][0].AddOutgoing(nodes[4][0].point);
            nodes[3][0].AddOutgoing(nodes[5][0].point);
            nodes[4][0].AddIncoming(nodes[3][0].point);
            nodes[5][0].AddIncoming(nodes[3][0].point);

            nodes[3][1].AddOutgoing(nodes[4][0].point);
            nodes[3][1].AddOutgoing(nodes[5][1].point);
            nodes[4][0].AddIncoming(nodes[3][1].point);
            nodes[5][1].AddIncoming(nodes[3][1].point);

            nodes[4][0].AddOutgoing(nodes[5][0].point);
            nodes[4][0].AddOutgoing(nodes[5][1].point);
            nodes[5][0].AddIncoming(nodes[4][0].point);
            nodes[5][1].AddIncoming(nodes[4][0].point);

            nodes[5][0].AddOutgoing(nodes[6][0].point);
            nodes[6][0].AddIncoming(nodes[5][0].point);

            nodes[5][1].AddOutgoing(nodes[6][0].point);
            nodes[6][0].AddIncoming(nodes[5][1].point);
        }

        private static void FirstConnections()
        {
            nodes[0][0].AddOutgoing(nodes[1][0].point);
            nodes[0][0].AddOutgoing(nodes[1][1].point);
            nodes[0][0].AddOutgoing(nodes[1][2].point);
            nodes[1][0].AddIncoming(nodes[0][0].point);
            nodes[1][1].AddIncoming(nodes[0][0].point);
            nodes[1][2].AddIncoming(nodes[0][0].point);

            nodes[1][0].AddOutgoing(nodes[2][0].point);
            nodes[1][1].AddOutgoing(nodes[2][0].point);
            nodes[1][1].AddOutgoing(nodes[2][1].point);
            nodes[1][2].AddOutgoing(nodes[2][1].point);
            nodes[2][0].AddIncoming(nodes[1][0].point);
            nodes[2][0].AddIncoming(nodes[1][1].point);
            nodes[2][1].AddIncoming(nodes[1][1].point);
            nodes[2][1].AddIncoming(nodes[1][2].point);

            nodes[2][0].AddOutgoing(nodes[3][0].point);
            nodes[2][1].AddOutgoing(nodes[3][0].point);
            nodes[3][0].AddIncoming(nodes[2][0].point);
            nodes[3][0].AddIncoming(nodes[2][1].point);

            nodes[3][0].AddOutgoing(nodes[4][0].point);
            nodes[4][0].AddIncoming(nodes[3][0].point);

            nodes[4][0].AddOutgoing(nodes[5][0].point);
            nodes[4][0].AddOutgoing(nodes[5][1].point);
            nodes[4][0].AddOutgoing(nodes[5][2].point);
            nodes[5][0].AddIncoming(nodes[4][0].point);
            nodes[5][1].AddIncoming(nodes[4][0].point);
            nodes[5][2].AddIncoming(nodes[4][0].point);

            nodes[5][0].AddOutgoing(nodes[6][0].point);
            nodes[6][0].AddIncoming(nodes[5][0].point);

            nodes[6][0].AddOutgoing(nodes[7][0].point);
            nodes[5][1].AddOutgoing(nodes[7][0].point);
            nodes[5][2].AddOutgoing(nodes[7][0].point);
            nodes[7][0].AddIncoming(nodes[6][0].point);
            nodes[7][0].AddIncoming(nodes[5][1].point);
            nodes[7][0].AddIncoming(nodes[5][2].point);

            nodes[7][0].AddOutgoing(nodes[8][0].point);
            nodes[7][0].AddOutgoing(nodes[8][1].point);
            nodes[7][0].AddOutgoing(nodes[8][2].point);
            nodes[8][0].AddIncoming(nodes[7][0].point);
            nodes[8][1].AddIncoming(nodes[7][0].point);
            nodes[8][2].AddIncoming(nodes[7][0].point);

            nodes[8][0].AddOutgoing(nodes[9][0].point);
            nodes[8][1].AddOutgoing(nodes[9][0].point);
            nodes[8][2].AddOutgoing(nodes[9][0].point);
            nodes[9][0].AddIncoming(nodes[8][0].point);
            nodes[9][0].AddIncoming(nodes[8][1].point);
            nodes[9][0].AddIncoming(nodes[8][2].point);
        }

        private static void DemoConnections()
        {
            nodes[0][0].AddOutgoing(nodes[1][0].point);
            nodes[0][0].AddOutgoing(nodes[1][1].point);
            nodes[0][0].AddOutgoing(nodes[1][2].point);
            nodes[1][0].AddIncoming(nodes[0][0].point);
            nodes[1][1].AddIncoming(nodes[0][0].point);
            nodes[1][2].AddIncoming(nodes[0][0].point);

            nodes[1][0].AddOutgoing(nodes[2][0].point);
            nodes[1][1].AddOutgoing(nodes[2][0].point);
            nodes[1][2].AddOutgoing(nodes[2][0].point);
            nodes[2][0].AddIncoming(nodes[1][0].point);
            nodes[2][0].AddIncoming(nodes[1][1].point);
            nodes[2][0].AddIncoming(nodes[1][2].point);

            nodes[2][0].AddOutgoing(nodes[3][0].point);
            nodes[2][0].AddOutgoing(nodes[3][1].point);
            nodes[2][0].AddOutgoing(nodes[3][2].point);
            nodes[3][0].AddIncoming(nodes[2][0].point);
            nodes[3][1].AddIncoming(nodes[2][0].point);
            nodes[3][2].AddIncoming(nodes[2][0].point);

            nodes[3][0].AddOutgoing(nodes[4][0].point);
            nodes[3][1].AddOutgoing(nodes[4][0].point);
            nodes[3][2].AddOutgoing(nodes[4][0].point);
            nodes[4][0].AddIncoming(nodes[3][0].point);
            nodes[4][0].AddIncoming(nodes[3][1].point);
            nodes[4][0].AddIncoming(nodes[3][2].point);

            nodes[4][0].AddOutgoing(nodes[5][0].point);
            nodes[5][0].AddIncoming(nodes[4][0].point);
        }
    }
}