using System;
using System.IO;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Populations;
using GA;
using GeneticSharp.Infrastructure.Framework.Reflection;
using System.Threading;

namespace GA
{
    public class Program
    {
        public static void Main()
        {

            for (int i = 1; i <= 100; i++)
            {
                Thread t = new Thread(GetParamsAndRun);
                t.Start(i);
            }

        }

        public static void GetParamsAndRun(object i)
        {
            Console.WriteLine("Thread" + i);
                    Program prog = new Program();
                    Guid guid = Guid.NewGuid();                    
                    prog.Run((int)i, guid);
        }

        public void Run(int ID, Guid guid)
        {


            DrawSampleName("Binary File Evolution");
            BinaryFileEqualitySampleController bf = new BinaryFileEqualitySampleController(ID, guid);
            bf.Initialize();

            Console.WriteLine("Starting...");

            var selection = bf.CreateSelection();
            var crossover = bf.CreateCrossover();
            var mutation = bf.CreateMutation();
            var fitness = bf.CreateFitness();
            var population = new Population(10, 20, bf.CreateChromosome())
            {
                GenerationStrategy = new PerformanceGenerationStrategy()
            };

            var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
            {
                Termination = bf.CreateTermination()
            };

            var terminationName = ga.Termination.GetType().Name;

            ga.GenerationRan += delegate
            {
                DrawSampleName("Binary File Evolution");

                var bestChromosome = ga.Population.BestChromosome;
                Console.WriteLine("Termination: {0}", terminationName);
                Console.WriteLine("Generations: {0}", ga.Population.GenerationsNumber);
                Console.WriteLine("Fitness: {0,10}", bestChromosome.Fitness);
                Console.WriteLine("Time: {0}", ga.TimeEvolving);
                Console.WriteLine("Speed (gen/sec): {0:0.0000}", ga.Population.GenerationsNumber / ga.TimeEvolving.TotalSeconds);
                bf.Draw(bestChromosome);
            };

            try
            {
                bf.ConfigGA(ga);
                ga.Start();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("Error: {0}", ex.Message);
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine();
            Console.WriteLine("Evolved.");
            Console.ResetColor();
            Console.ReadKey();
        }
        private static void DrawSampleName(string selectedSampleName)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("GeneticSharp - ConsoleApp");
            Console.WriteLine();
            Console.WriteLine(selectedSampleName);
            Console.ResetColor();
        }
    }
}
