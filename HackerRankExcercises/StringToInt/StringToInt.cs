using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeExcercises
{
    internal class StringToInt
    {
        public static int MyAtoi(string s)
        {
            if (s.Length == 0 || (s.Length == 1 && s[0] == 0))
                return 0;

            int startIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                //If the char is not a space, break
                if (s[i] != ' ')
                {
                    startIndex = i;
                    break;
                }
            }

            long result = 0;
            int sign = 1;
            List<char> arr = new List<char>();                        

            if (s[startIndex] == '-')
            {
                sign = -1;
                startIndex = startIndex + 1;
            }
            else if (s[startIndex] == '+')
            {
                sign = 1;
                startIndex = startIndex + 1;
            }

            //Go through the string until there is a non-digit char
            for (int i = startIndex; i < s.Length; i++)
            {
                if (!Char.IsDigit(s[i]))
                    break;

                arr.Add(s[i]);
            }

            for (int j = 0; j < arr.Count; j++)
            {
                long currentNum = arr[j] - '0';
                long currentPow = arr.Count - 1 - j;
                var poweredNum = Math.Pow(10, currentPow);

                if(currentNum == 0)
                    continue;

                if (poweredNum * sign > int.MaxValue)
                    return int.MaxValue;
                else if (poweredNum * sign < int.MinValue)
                    return int.MinValue;

                if (currentPow > 0)
                    result += currentNum * ((long)poweredNum);
                else
                    result += currentNum;
            }

            result = result * sign;

            if (result < int.MinValue)
                return int.MinValue;

            if (result > int.MaxValue)
                return int.MaxValue;

            return (int)result;
        }
    }
}
