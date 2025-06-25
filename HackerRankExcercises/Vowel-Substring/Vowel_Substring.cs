using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeExcercises
{
    static class Vowel_Substring
    {
        public static string findSubstring(string s, int k)
        {
            string[] substrings = new string[s.Length - k + 1];
            int[] vowelCounts = new int[s.Length - k + 1];
            int maxCountIndex = 0;

            for (int i = 0; i < s.Length - k + 1; i++)
            {
                substrings[i] = s.Substring(i, k);
                int vowelsCount = 0;

                for (int j = 0; j < substrings[i].Length; j++)
                {
                    if (IsVowel(substrings[i][j]))
                    {
                        vowelsCount++;
                    }
                }

                vowelCounts[i] = vowelsCount;

                if (vowelCounts[i] > vowelCounts[maxCountIndex])
                {
                    maxCountIndex = i;
                }
            }

            return substrings[maxCountIndex];
        }

        private static bool IsVowel(char c)
        {
            return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
        }

        public static void RunExercise()
        {
            Console.WriteLine(findSubstring("azerdii", 5));
        }
    }
}
