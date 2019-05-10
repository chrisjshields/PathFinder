using System;

namespace PathFinder
{
    internal class Program
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

            var pathFinder = new PathFinder(SampleMaps.CreateSampleMap());
            bool success = pathFinder.FindShortestRoute(char.ToUpper(start), char.ToUpper(end));
            if (success)
                WritePathToConsole(pathFinder);
            else
                Console.WriteLine("Error: " + pathFinder.Error);
        }

        private static void WritePathToConsole(PathFinder path)
        {
            var first = true;
            foreach (Node node in path.GetNodeSequence())
            {
                if (!first)
                    Console.Write(" => ");

                Console.Write(node.Name);
                first = false;
            }

            Console.WriteLine(Environment.NewLine + "Distance: " + path.GetDistance());
        }
    }
}
