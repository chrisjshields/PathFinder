using System.Collections.Generic;

namespace PathFinder
{
    public class SampleMaps
    {
        public static Map CreateSampleMap()
        {
            var nodes = new Nodes()
            {
                { new Node('A') },
                { new Node('B') },
                { new Node('C') },
                { new Node('D') },
                { new Node('E') },
                { new Node('F') },
                { new Node('G') },
                { new Node('H') },
            };

            var roads = new List<Road>()
            {
                new Road(nodes['A'], nodes['C'], 2),
                new Road(nodes['C'], nodes['D'], 1),
                new Road(nodes['C'], nodes['F'], 4),
                new Road(nodes['B'], nodes['D'], 4),
                new Road(nodes['B'], nodes['E'], 7),
                new Road(nodes['D'], nodes['F'], 1),
                new Road(nodes['D'], nodes['G'], 2),
                new Road(nodes['F'], nodes['G'], 3),
                new Road(nodes['G'], nodes['H'], 4),
                new Road(nodes['E'], nodes['H'], 10)
            };
            
            return new Map(nodes, roads);
        }
    }
}
