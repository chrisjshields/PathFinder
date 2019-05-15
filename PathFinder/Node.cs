using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder
{
    public class Node
    {
        public char Name { get; private set; }
        public Node PreviousNode { get; set; }
        public bool Visited { get; set; }
        public int Distance { get; set; }
        private List<Neighbour> _neighbours { get; set; }

        public Node(char name)
        {
            Name = name;
            _neighbours = new List<Neighbour>();
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        public void AddNeighbour(Node node, int distance)
        {
            _neighbours.Add(new Neighbour(node, distance));
        }

        public IEnumerable<Neighbour> GetUnvisitedNeighbours()
        {
            return _neighbours.Where(i => !i.Node.Visited);
        }
    }

    public class Nodes : IEnumerable<Node>
    {
        readonly List<Node> _nodes = new List<Node>();

        public Node this[char name]  
        {  
            // Allow lookup by node name using []
            get { return _nodes.Single(i => i.Name == name); }  
            set { _nodes.Insert(_nodes.IndexOf(_nodes.Single(i => i.Name == name)), value); }  
        }

        public void Add(Node node)
        {
            _nodes.Add(node);
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
