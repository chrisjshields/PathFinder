using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PathFinder
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // Defaults to be used if no command line arguments are provided
            char start = 'B';
            char end = 'H';

            if (args.Length == 2)
            {
                start = args[0].ToCharArray()[0];
                end = args[1].ToCharArray()[0];
            }

            try
            {
                var pathFinder = new PathFinder(SampleMaps.CreateSampleMap());
                var route = pathFinder.GetShortestRoute(char.ToUpper(start), char.ToUpper(end));
                WriteRouteToConsole(route);
                Console.WriteLine(Environment.NewLine + "Distance: " + pathFinder.GetDistance());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static void WriteRouteToConsole(List<Node> route)
        {
            var first = true;
            foreach (Node node in route)
            {
                if (!first)
                    Console.Write(" => ");

                Console.Write(node.Name);
                first = false;
            }
        }
    }
}
