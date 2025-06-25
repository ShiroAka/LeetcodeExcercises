using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeExcercises
{
    internal class IntToRoman
    {
        //This was extracted from a LeetCode problem (12. Integer to Roman)
        //My solution --> https://leetcode.com/problems/integer-to-roman/submissions/1672072611/
        public static string IntToRomanV1(int num)
        {
            string numStr = num.ToString();
            string result = String.Empty;

            string[] tenPowers = new string[] { "M", "C", "X", "I" };
            string[] fivePowers = new string[] { "", "D", "L", "V" };
            int basePower = 4 - numStr.Length;

            for (int i = 0; i < numStr.Length; i++)
            {
                int currentNumber = numStr[i] - '0';
                int currentPower = basePower + i;

                if (currentNumber == 4)
                {
                    result += tenPowers[currentPower];
                    result += fivePowers[currentPower];
                }
                else if (currentNumber == 9)
                {
                    result += tenPowers[currentPower];
                    result += tenPowers[currentPower - 1];
                }
                else if (currentNumber >= 5)
                {
                    result += fivePowers[currentPower];

                    for (int j = 0; j < currentNumber - 5; j++)
                    {
                        result += tenPowers[currentPower];
                    }
                }
                else
                {
                    for (int j = 0; j < currentNumber; j++)
                    {
                        result += tenPowers[currentPower];
                    }
                }
            }

            return result;
        }
    }
}
