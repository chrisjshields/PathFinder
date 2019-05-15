namespace PathFinder
{
    public class Neighbour
    {
        public Node Node { get; }
        public int Distance { get; }
        public Neighbour(Node node, int distance)
        {
            Node = node;
            Distance = distance;
        }
    }
}
