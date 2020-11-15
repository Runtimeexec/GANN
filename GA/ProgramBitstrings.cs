using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Randomizations;
using GeneticSharp.Infrastructure;

namespace GA
{
    static class Fitness
    {

        public static class ConvertBitstring
        {
            /// <summary>
            /// Use to convert Complete Chromosome Bitstring Array to a Bit Array for mutations / flips etc.
            /// </summary>
            /// <param name="s">The BitString</param>
            /// <returns>BitArray</returns>
            public static BitArray ConvertBitstring2BitArray(string s)
            {
                var res = new BitArray(s.Select(c => c == '1').ToArray());
                return res;
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

            /// <summary>
            /// Convert BitString to byte array
            /// </summary>
            /// <param name="bitString"></param>
            /// <returns></returns>
            public static byte[] GetBytes(string bitString)
            {
                return Enumerable.Range(0, bitString.Length / 8).
                    Select(pos => Convert.ToByte(
                        bitString.Substring(pos * 8, 8),
                        2)
                    ).ToArray();
            }


            /// <summary>
            /// Covert byte array to shorts for insertion into db as tinyint
            /// </summary>
            /// <param name="b"></param>
            /// <returns></returns>
            public static IList<Int16> Bytearray2Short(byte[] b)
            {                          
                Int16[] shrts = new Int16[b.Length];
                Buffer.BlockCopy(b, 0, shrts, 0, b.Length);

                return shrts;
            }

            /// <summary>
            /// Convert List of Shorts to string
            /// </summary>
            /// <param name="i">IList</param>
            /// <returns>string</returns>
            public static string ShortListToString(IList<Int16> i)
            {
                string shrts = "";
                foreach(Int16 int16 in i)
                {
                    shrts += int16.ToString();
                }
                return shrts;
            }
        }

        /// <summary>
        /// Hamming Distance Algorithm 
        /// The Hamming Distance measures the minimum number of substitutions required to change one string into the other. 
        /// The Hamming distance between two strings of equal length is the number of positions at which the corresponding symbols are different. 
        /// The Hamming distance is named after Richard Hamming.        
        /// </summary>
        public static class StringDistance
        {
            public static int GetHammingDistance(string s, string t)
            {
                if (s.Length != t.Length)
                {
                    throw new Exception("Strings must be equal length");
                }

                //Zip Function lays two collections on top of one another so that each individual position can be compared
                int distance =
                    s.ToCharArray()
                    .Zip(t.ToCharArray(), (c1, c2) => new { c1, c2 })
                    .Count(m => m.c1 != m.c2);

                return distance;
            }
        }
    }
    class ProgramBitstrings
    {
        static void Main(string[] args)
        {
            var res = Fitness.ConvertBitstring.ConvertBitstring2BitArray("10011101");
            var res2 = Fitness.ConvertBitstring.ConvertShort2Bitstring(res);
            Console.WriteLine(res2);
            var res3 = Fitness.ConvertBitstring.GetBytes(res2);
            Console.WriteLine(res3);
            var res4 = Fitness.ConvertBitstring.Bytearray2Short(res3);
            Console.WriteLine(res4);
            var res5 = Fitness.ConvertBitstring.ShortListToString(res4);
            Console.WriteLine(res5);

            Console.WriteLine(Fitness.StringDistance.GetHammingDistance("11111111", "00000000"));
            Console.WriteLine(Fitness.StringDistance.GetHammingDistance("10011101", "00000000"));
            Console.WriteLine(Fitness.StringDistance.GetHammingDistance("00111101", "00111101"));

            TinyIntChromosome tinyIntChromosome = new TinyIntChromosome(1000, 0 , 2);
        }
    }

    public class TinyIntChromosome : BinaryChromosomeBase
    {
        private readonly int m_minValue;
        private readonly int m_maxValue;
        private readonly int m_length;
        private readonly BitArray m_originalValue;
        public TinyIntChromosome(int length, int minValue, int maxValue)
            : base(length)
        {
            m_minValue = minValue;
            m_maxValue = maxValue;
            m_length = length;

            var intValue = RandomizationProvider.Current.GetInt(m_minValue, m_maxValue);

            //Original Chromosome seeded with random 1's and 0's
            m_originalValue = new BitArray(new int[] { intValue });

            CreateGenes();
        }
        /// <summary>
        /// Creates New Chromosome of length m_length e.g. 1000 genes of type bit
        /// </summary>
        /// <returns>IChromosome</returns>
        public override IChromosome CreateNew()
        {
            return new TinyIntChromosome(m_length, m_minValue, m_maxValue);
        }

    }

}
