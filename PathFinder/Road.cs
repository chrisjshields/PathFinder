namespace PathFinder
{
    public class Road
    {
        internal Node Node1 { get; }
        internal Node Node2 { get; }
        internal int Distance { get; }

        public Road(Node node1, Node node2, int distance)
        {
            Node1 = node1;
            Node2 = node2;
            Distance = distance;
        }
    }
}
