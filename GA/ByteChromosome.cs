using Accord;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Randomizations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    /// <summary>
    /// Int16 chromosome with binary values (0 and 1).
    /// </summary>
    public class ByteChromosome : BinaryChromosomeBase
    {
        private readonly int m_minValue;
        private readonly int m_maxValue;
        private readonly BitArray m_originalValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:GeneticSharp.Domain.Chromosomes.Int16Chromosome"/> class.
        /// </summary>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Maximum value.</param>
        public ByteChromosome(int minValue, int maxValue) : base(8000)
        {
            m_minValue = minValue;
            m_maxValue = maxValue;
            BitArray ba1 = new BitArray(0);
            for (int i = 0; i < 8000; i++)
            {
                Byte[] b = new byte[1];
                var intValue = RandomizationProvider.Current.GetInt(m_minValue, m_maxValue);
                b[0] = (byte)intValue;
                var ba2 = new BitArray(b);
                ba1 = Utilities.BitArray(ba2, ba1);
            }

            m_originalValue = ba1;


            CreateGenes();
        }

        /// <summary>
        /// Generates the gene.
        /// </summary>
        /// <returns>The gene.</returns>
        /// <param name="geneIndex">Gene index.</param>
        public override Gene GenerateGene(int geneIndex)
        {
            var value = m_originalValue[geneIndex];
            return new Gene(value);
        }

        /// <summary>
        /// Creates the new.
        /// </summary>
        /// <returns>The new.</returns>
        public override IChromosome CreateNew()
        {
            return new ByteChromosome(0, 2);
        }

        /// <summary>
        /// Converts the chromosome to its integer representation.
        /// </summary>
        /// <returns>The integer.</returns>
        public int ToInteger()
        {
            var array = new int[1];
            var genes = GetGenes().Select(g => (bool)g.Value).ToArray();
            var bitArray = new BitArray(genes);
            bitArray.CopyTo(array, 0);

            return array[0];
        }

        /// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:GeneticSharp.Domain.Chromosomes.FloatingPointChromosome"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:GeneticSharp.Domain.Chromosomes.FloatingPointChromosome"/>.</returns>
		public override string ToString()
        {
            return String.Join("", GetGenes().Reverse().Select(g => (bool)g.Value ? "1" : "0").ToArray());
        }

        /// <summary>
        /// Flips the gene.
        /// </summary>
        /// <remarks>>
        /// If gene's value is 0, the it will be flip to 1 and vice-versa.</remarks>
        /// <param name="index">The gene index.</param>
        public override void FlipGene(int index)
        {
            var realIndex = Math.Abs(31 - index);
            var value = (bool)GetGene(realIndex).Value;

            ReplaceGene(realIndex, new Gene(!value));
        }

        public string BuildBitstringFile()
        {
            //build bit string 
            string bitstring = string.Empty;
            bitstring = ToString();
            return bitstring;

        }
    }
    public static class Utilities
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

