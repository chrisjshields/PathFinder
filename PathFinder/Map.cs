using System.Collections.Generic;
using System.Linq;

namespace PathFinder
{
    public class Map
    {
        public Nodes Nodes { get; }
        public List<Road> Roads { get; }
        public Node CurrentLocation { get; private set; }

        public Map(Nodes nodes, List<Road> roads)
        {
            Nodes = nodes;
            Roads = roads;

            foreach (var road in roads)
            {
                road.Node1.AddNeighbour(road.Node2, road.Distance);
                road.Node2.AddNeighbour(road.Node1, road.Distance);
            }
        }

        public bool MoveToNextUnvisitedNode()
        {
            Node unvisitedNode = Nodes.Where(i => !i.Visited && i.Distance != int.MaxValue).OrderBy(i => i.Distance).FirstOrDefault();
            
            // Return false if there are no more unvisited connected nodes 
            if (unvisitedNode == null)
                return false;
            
            CurrentLocation = unvisitedNode;
            return true;
        }
    }
}
