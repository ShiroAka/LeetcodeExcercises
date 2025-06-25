using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeExcercises
{
    static class DeterminingDNAHealth
    {
		private static int GetStrandHealth(string[] genes, int[] genesHealth, int genesCount, string strand, int minGeneArrayIndex, int maxGeneArrayIndex)
		{
			int totalStrandHealth = 0;

			for (int i = minGeneArrayIndex; (i <= maxGeneArrayIndex) && (i < genesCount); i++)
			{
				string geneString = genes[i];
				int geneHealth = genesHealth[i];

				int geneStringOccurrences = CountSubStringOccurrences(strand, geneString);

				totalStrandHealth += geneStringOccurrences * geneHealth;
			}

			return totalStrandHealth;
		}


		private static int CountSubStringOccurrences(string source, string subString)
		{
			int count = 0;

			for (int i = 0; i <= (source.Length - subString.Length); i++)
			{
				string temp = source.Substring(i, subString.Length);

				if (temp == subString)
					count++;
			}

			return count;
		}

		public static void RunExercise()
        {
            int geneCount = Convert.ToInt32(Console.ReadLine());

            string[] genes = Console.ReadLine().Split(' ');

            int[] genesHealth = Array.ConvertAll(Console.ReadLine().Split(' '), healthTemp => Convert.ToInt32(healthTemp));

            int strandCount = Convert.ToInt32(Console.ReadLine());


			/* The following values are needed for the validations to work corectly in the end of the 'for' cycle
			   Otherwise I would have to process one strand outside the 'for' cycle to set the initial values of 
			   the following variables */
			uint minStrandHealth = uint.MaxValue; //Very high value
			uint maxStrandHealth = uint.MinValue; //0 (zero)

			for (int sItr = 0; sItr < strandCount; sItr++)
            {
                string[] geneIndexesAndStrand = Console.ReadLine().Split(' ');

                int minIndex = Convert.ToInt32(geneIndexesAndStrand[0]);

                int maxIndex = Convert.ToInt32(geneIndexesAndStrand[1]);

                string strand = geneIndexesAndStrand[2];

				int strandHealth = GetStrandHealth(genes, genesHealth, geneCount, strand, minIndex, maxIndex);

				if (strandHealth < minStrandHealth)
					minStrandHealth = (uint)strandHealth;

				if (strandHealth > maxStrandHealth)
					maxStrandHealth = (uint)strandHealth;
			}

			Console.WriteLine("{0} {1}", minStrandHealth, maxStrandHealth);
        }
    }
}