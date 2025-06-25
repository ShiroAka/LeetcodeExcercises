using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeExcercises.RomanToInt
{
    internal class RomanToInt
    {
        private Dictionary<char, int> romanNumberValues = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000},
        };

        //The worst solution I could come up with, but it works
        public int RomanToIntV1(string s)
        {
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    //All these cases follow the same logic, there should be a way to join them into one function
                    case 'I':
                        result += 1;

                        if (i + 1 < s.Length)
                        {
                            if (s[i + 1] == 'V')
                            {
                                result += 3;    //Need to add 4, but I already added 1 above
                                i++;
                            }
                            else if (s[i + 1] == 'X')
                            {
                                result += 8;
                                i++;
                            }
                        }
                        break;

                    case 'X':
                        result += 10;

                        if (i + 1 < s.Length)
                        {
                            if (s[i + 1] == 'L')
                            {
                                result += 30;    //Need to add 40, but I already added 10 above
                                i++;
                            }
                            else if (s[i + 1] == 'C')
                            {
                                result += 80;
                                i++;
                            }
                        }
                        break;

                    case 'C':
                        result += 100;

                        if (i + 1 < s.Length)
                        {
                            if (s[i + 1] == 'D')
                            {
                                result += 300;    //Need to add 400, but I already added 100 above
                                i++;
                            }
                            else if (s[i + 1] == 'M')
                            {
                                result += 800;
                                i++;
                            }
                        }
                        break;

                    default:
                        result += romanNumberValues[s[i]];
                        break;
                }
            }

            return result;
        }

        //Unified all 3 switch cases in the above function with the help of Copilot
        //Still not a good solution according to the LeetCode page --> https://leetcode.com/problems/roman-to-integer/
        public int RomanToIntV2(string s)
        {
            Dictionary<string, int> edgeCases = new Dictionary<string, int>
            {
                {"IV", 4},
                {"IX", 9},
                {"XL", 40},
                {"XC", 90},
                {"CD", 400},
                {"CM", 900}
            };

            int result = 0;
            int i = 0;

            while (i < s.Length)
            {
                if (i + 1 < s.Length && edgeCases.TryGetValue(s.Substring(i, 2), out int pairValue))
                {
                    result += pairValue;
                    i += 2;
                }
                else
                {
                    result += romanNumberValues[s[i]];
                    i++;
                }
            }

            return result;
        }

        //This is the fastest solution I could come up with
        //My solution --> https://leetcode.com/problems/roman-to-integer/submissions/1672102665/
        public int RomanToIntV3(string s)
        {
            int result = 0;
            int currentValue = 0;
            int nextValue = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {
                currentValue = RomanCharToInt(s[i]);
                nextValue = RomanCharToInt(s[i + 1]);

                //If the current character is less than the next one, it means we need to subtract the current value (cause it is a special case like IV, IX, etc.)
                //e.g.: IX = 9 = 10 - 1 --> I subtract 1 from the result and in the next iteration I will add 10
                if (currentValue < nextValue)
                {
                    result -= currentValue;
                }
                else
                {
                    result += currentValue;
                }
            }

            return result + RomanCharToInt(s[s.Length - 1]); //Add the last character value, since it is not included in the loop above
        }

        //This is faster an uses less memory than a dictionary
        private int RomanCharToInt(char romanChar)
        {
            switch (romanChar)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }
    }
}
