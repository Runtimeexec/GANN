using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Terminations;
using GeneticSharp.Extensions.Drawing;
using GeneticSharp.Infrastructure.Framework.Texts;
using GeneticSharp.Infrastructure.Framework.Commons;
using ImageMagick;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using Accord.Math;
using Accord.Math.Distances;
using GeneticSharp.Extensions.Mathematic;

namespace GA
{
    [DisplayName("Binary File Evolution")]
    public class BinaryFileEqualitySampleController : SampleControllerBase
    {
        private ByteFileEqualityFitness m_fitness;
        private IChromosome m_lastBest;
        private string m_destFolder;

        public string ID { get; private set; }
        public string Guid { get; private set; }

        public BinaryFileEqualitySampleController(int ID, Guid guid)
        {
            this.ID = ID.ToString();
            this.Guid = guid.ToString();
        }

        #region implemented abstract members of SampleControllerBase

        public override IChromosome CreateChromosome()
        {
            return new ByteChromosome(0, 2);
        }

        public override IFitness CreateFitness()
        {
            return m_fitness;
        }

        public override ITermination CreateTermination()
        {
            //return new TimeEvolvingTermination(TimeSpan.FromMinutes(m_minutesToEvolve));
            return new GenerationNumberTermination(1000);
        }

        public override IMutation CreateMutation()
        {
            return new TworsMutation();
        }

        public override GeneticSharp.Domain.Crossovers.ICrossover CreateCrossover()
        {
            return new UniformCrossover();
        }

        public override void Initialize()
        {
            base.Initialize();

            List<BitArray> bitArrays = new List<BitArray>();

            Console.WriteLine("Input binary file:");
            //var inputBitstringFile = Console.ReadLine();

            string connectionString = "Server=GANN;Database=gann;User Id=gann_user;Password=[PASSWORD];";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("select * from TinyInt where ID = " + ID, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    BitArray ba1 = new BitArray(0);
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["ID"].ToString());

                        List<short> list = new List<short>();
                        for (int i = 1; i <= 1000; i++)
                        {
                            Console.WriteLine(reader["Tinyint" + i].ToString());

                            Byte[] b = new byte[1];
                            var num = reader.GetByte(reader.GetOrdinal("Tinyint" + i));
                            b[0] = num;
                            var ba2 = new BitArray(b);
                            ba1 = Utilities.BitArray(ba2, ba1);
                        }
                    }

                    Console.WriteLine(ba1.Length);
                    Console.WriteLine(ba1.Count);
                    //Console.WriteLine(Distance.Hamming(ba1, ba1));
                    bitArrays.Add(ba1);
                    
                }
            }



            var targetBinaryFile = bitArrays[0];
            m_fitness = new ByteFileEqualityFitness(targetBinaryFile);

            //var folder = Path.Combine(Path.GetDirectoryName(inputBitstringFile), "results");
            //m_destFolder = "{0}_{1:yyyyMMdd_HHmmss}".With(folder, DateTime.Now);
            //Directory.CreateDirectory(m_destFolder);
            //Console.WriteLine("Results Biststrings will be written to '{0}'.", m_destFolder);

            //Console.WriteLine("Start Evolving...");
            //Console.WriteLine("Minutes to evolve:");
            //m_minutesToEvolve = Convert.ToInt32(Console.ReadLine());
        }

        public override void ConfigGA(GeneticAlgorithm ga)
        {
            base.ConfigGA(ga);
            ga.MutationProbability = 0.4f;
            ga.TerminationReached += (sender, args) =>
            {
                
            };
        }

        public override void Draw(IChromosome bestChromosome)
        {
            var folder = Path.Combine(Path.GetDirectoryName(@"./"), "Bitstrings");
            m_destFolder = folder;
            Directory.CreateDirectory(m_destFolder);

            if (GA.GenerationsNumber == 1 || (GA.GenerationsNumber % 10 == 0 && m_lastBest.Fitness != bestChromosome.Fitness))
            {
                var best = bestChromosome as ByteChromosome;

                var bitstringFile = best.BuildBitstringFile();

                System.IO.StreamWriter file;
                using (file = new StreamWriter(string.Format("{0}/{1}_{2}_{3}_{4}.txt", m_destFolder, GA.GenerationsNumber.ToString("D10"), best.Fitness, ID, Guid), true))
                {
                    file.Write(bitstringFile);

                }
                m_lastBest = best;
            }
        }

        #endregion
    }

    static class UtilitiesTest
    {
        public static BitArray BitArray(BitArray current, BitArray after)
        {
            var bools = new bool[current.Count + after.Count];
            current.CopyTo(bools, 0);
            after.CopyTo(bools, current.Count);
            return new BitArray(bools);
        }

        /// <summary>
        ///Use to convert every eight bits in a Bitarray to a Bitstring, 
        ///these will need to be converted to tinyints for the NN and storage in the db 
        ///and concatenated so that the Hammer Algorithm can be used
        /// </summary>
        /// <param name="bits">BitArry</param>
        /// <returns>BitString</returns>
        public static string ConvertShort2Bitstring(BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            //return bytes[0];

            byte decimalNumber = bytes[0]; ;
            string result = string.Empty;

            while (decimalNumber > 0)
            {

                int remainder = decimalNumber % 2;
                decimalNumber /= 2;
                result += remainder.ToString();

            }
            return result;
        }

        public static IList<Int16> Bytearray2Short(byte[] b)
        {
            Int16[] shrts = new Int16[b.Length];
            Buffer.BlockCopy(b, 0, shrts, 0, b.Length);

            return shrts;
        }

        public static string ShortListToString(IList<Int16> i)
        {
            string shrts = "";
            foreach (Int16 int16 in i)
            {
                shrts += int16.ToString();
            }
            return shrts;
        }

        public static BitArray ConvertBitstring2BitArray(string s)
        {
            var res = new BitArray(s.Select(c => c == '1').ToArray());
            return res;
        }

        public static string ConvertDecimal2Bitstring(byte decimalNumber)
        {
            byte remainder;
            string result = string.Empty;
            while (decimalNumber > 0)
            {
                remainder = (byte)(decimalNumber % 2);
                decimalNumber /= 2;
                result = remainder.ToString() + result;
            }
            return result;
        }
    }
}