
using System;

namespace LeetcodeExcercises
{
    public static class NumberToEnglishWordsV2
    {
        private static string[] LessThan20 = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static string[] Tens = new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private static string[] Thousands = new string[] { "", "Thousand", "Million", "Billion" };

        public static string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            string result = string.Empty;
            string numStr = num.ToString();
            int threeNumSubstrings = (numStr.Length % 3) == 0 ? (numStr.Length / 3) : (numStr.Length / 3) + 1; //if up to 3 digits, we have 1 substring, if up to 6 digits, we have 2 substrings, etc.

            for (int i = threeNumSubstrings; i > 0; i--)
            {
                int substring;

                if (i == 1)
                {
                    substring = num % 1000;
                }
                else
                {
                    substring = num / (int)Math.Pow(1000, i - 1);
                }

                if(substring > 0)
                {
                    result += ConvertHundreds(substring);
                    result += Thousands[i - 1] + " ";

                    num -= substring * (int)Math.Pow(1000, i - 1); //Remove the processed substring from the number; otherwise the above ifs will not work
                }
            }

            return result.Trim();
        }

        //This is a bit more efficient than parsing the string
        private static string ConvertHundreds(int num)
        {
            string result = string.Empty;

            if (num == 0)
                return "";

            if (num < 20)
                result = LessThan20[num] + " ";

            //Two digit numbers
            if (num < 100)
            {
                result = ConvertTwoDigitNum(num);
            }
            else
            {
                int hundreds = num / 100;
                int twoDigitNum = num % 100;

                result = LessThan20[hundreds] + " Hundred ";
                result += ConvertTwoDigitNum(twoDigitNum);
            }

            return result;
        }

        private static string ConvertTwoDigitNum(int num)
        {
            if (num == 0)
                return "";

            if (num < 20)
            {
                return LessThan20[num] + " ";
            }
            else
            {
                int fstDigit = num / 10;
                int sndDigit = num % 10;

                return Tens[fstDigit] + " " + (sndDigit != 0 ? LessThan20[sndDigit] + " " : "");
            }
        }
    }
}
