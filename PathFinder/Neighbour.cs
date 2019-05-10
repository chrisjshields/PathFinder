namespace PathFinder
{
    internal class Neighbour
    {
        internal Node Node { get; }
        internal int Distance { get; }
        internal Neighbour(Node node, int distance)
        {
            Node = node;
            Distance = distance;
        }
    }
}
