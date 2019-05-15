namespace PathFinder
{
    public class Road
    {
        public Node Node1 { get; }
        public Node Node2 { get; }
        public int Distance { get; }

        public Road(Node node1, Node node2, int distance)
        {
            Node1 = node1;
            Node2 = node2;
            Distance = distance;
        }
    }
}
