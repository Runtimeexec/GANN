using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Accord.Math;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;

namespace GA
{
    /// <summary>
    /// Fitness based on this paper: Genetic Algorithm for Solving Simple Mathematical Equality Problem.
    /// <see href="http://arxiv.org/ftp/arxiv/papers/1308/1308.4675.pdf" />
    /// </summary>
    public class ByteFileEqualityFitness : IFitness
    {
        #region Fields
        //private IList<Color> m_targetBitmapPixels;
        private int m_pixelsCount;
        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="ByteFileEqualityFitness"/> class.
        /// </summary>
        /// <param name="targetFile">The target File.</param>
        public ByteFileEqualityFitness(BitArray targetFile)
            : this()
        {
            Initialize(targetFile);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapEqualityFitness"/> class.
        /// </summary>
        public ByteFileEqualityFitness()
        {
        }
        #endregion

        #region Properties        
        /// <summary>
        /// Gets the width of the bitmap.
        /// </summary>
        /// <value>
        /// The width of the bitmap.
        /// </value>
        public int BitmapWidth { get; private set; }

        /// <summary>
        /// Gets the height of the bitmap.
        /// </summary>
        /// <value>
        /// The height of the bitmap.
        /// </value>
        public int BitmapHeight { get; private set; }
        public BitArray targetFile { get; private set; }
        public BitArray newFile { get; private set; }
        #endregion

        #region Methods        
        /// <summary>
        /// Initializes the specified target bitmap.
        /// </summary>
        /// <param name="targetBitmap">The target bitmap.</param>
        public void Initialize(BitArray targetFile)
        {
            //BitmapWidth = targetBitmap.Width;
            //BitmapHeight = targetBitmap.Height;

            //m_targetBitmapPixels = BitmapChromosome.GetPixels(targetBitmap);
            //m_pixelsCount = m_targetBitmapPixels.Count;

            this.targetFile = targetFile;

        }

        /// <summary>
        /// Evaluates the specified chromosome.
        /// </summary>
        /// <param name="chromosome">The chromosome.</param>
        /// <returns>The chromosome fitness.</returns>
        public double Evaluate(IChromosome chromosome)
        {
            BitArray ba1 = new BitArray(0);
            foreach (Gene gene in chromosome.GetGenes())
            {
              var val = (bool)gene.Value;
                bool[] b = new bool[1];
                b[0] = val;
                var ba2 = new BitArray(b);
                ba1 = Utilities.BitArray(ba2, ba1);
            }
            newFile = ba1;
            double fitness = chromosome.Length;
            var ham = Distance.Hamming(newFile, targetFile);

            return fitness - ham;
        }

        #endregion
    }

    class Hamming
    {

        // Function to calculate 
        // hamming distance 
        static int hammingDistance(int n1, int n2)
        {
            int x = n1 ^ n2;
            int setBits = 0;

            while (x > 0)
            {
                setBits += x & 1;
                x >>= 1;
            }

            return setBits;
        }

        // Driver code 
        //static void Main()
        //{
        //    int n1 = 9, n2 = 14;
        //    System.Console.WriteLine(hammingDistance(n1, n2));
        //}
    }
}
