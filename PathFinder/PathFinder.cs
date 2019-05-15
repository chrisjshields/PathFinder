using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PathFinder
{
    public class PathFinder
    {
        private const string ERROR_BAD_DESTINATION = "Unable to reach destination";
        
        private readonly Map _map;

        public PathFinder(Map map)
        {
            _map = map;
        }

        public List<Node> GetShortestRoute(char origin, char destination)
        {
            var originNode = _map.Nodes[origin];
            var destinationNode = _map.Nodes[destination];
            Reset(originNode);

            while (!destinationNode.Visited)
            {
                if (!_map.MoveToNextUnvisitedNode())
                    throw new Exception(ERROR_BAD_DESTINATION);

                Debug.WriteLine($"Visiting {_map.CurrentLocation} ({_map.CurrentLocation.Distance})");

                foreach (var neighbour in _map.CurrentLocation.GetUnvisitedNeighbours())
                {
                    Debug.WriteLine($"  > {neighbour.Node} ({neighbour.Distance})");

                    // Calculate tentative distances through the current node
                    int distance = checked(_map.CurrentLocation.Distance + neighbour.Distance);
                    if (distance < neighbour.Node.Distance)
                    {
                        neighbour.Node.Distance = distance;
                        neighbour.Node.PreviousNode = _map.CurrentLocation;
                    }
                }
                
                _map.CurrentLocation.Visited = true;
            }

            return GetNodeSequence();
        }

        public int GetDistance()
        {
            return _map.CurrentLocation.Distance;
        }
        
        private List<Node> GetNodeSequence()
        {
            var breadCrumbs = new List<Node>();
            
            for(var p = _map.CurrentLocation; p != null; p = p.PreviousNode)
            {
                breadCrumbs.Insert(0, p);
            }

            return breadCrumbs;
        }

        private void Reset(Node originNode)
        {
            foreach (var node in _map.Nodes)
            {
                node.Visited = false;
                node.Distance = node == originNode ? 0 : int.MaxValue;
                node.PreviousNode = null;
            }
        }
    }
}
