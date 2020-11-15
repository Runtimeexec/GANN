using System;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;

namespace GA
{
    class ProgramTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World1!");
            var maxWidth = 10;
            var maxHeight = 10;
            var chromosome = new FloatingPointChromosome(
    new double[] { 0, 0, 0, 0 },
    new double[] { maxWidth, maxHeight, maxWidth, maxHeight },
    new int[] { 10, 10, 10, 10 },
    new int[] { 0, 0, 0, 0 });
            Console.WriteLine("Hello World24!");
            var counter = 0;
            var max = args.Length != 0 ? Convert.ToInt32(args[0]) : -1;
            while (max == -1 || counter < max)
            {
                counter++;
                Console.WriteLine($"Counter: {counter}");
                System.Threading.Tasks.Task.Delay(1000).Wait();
            }
        }
    }
}
