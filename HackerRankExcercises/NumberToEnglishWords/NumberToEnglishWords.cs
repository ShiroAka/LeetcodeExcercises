using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeExcercises
{
    public class NumberToEnglishWords
    {
        public static string NumberToWords(int num)
        {
            string result = string.Empty;
            int i = 0;

            string numStr = num.ToString();
            int thousandPower = (numStr.Length - 1) / 3; //If length is 9, thousandPower will be 2 (9 - 1) / 3 = 2 --> 2 substrings = Million and Thousand
            bool substringContainsNumbers = false;

            if (numStr.Length == 1 && numStr[0] == '0')
            {
                return "Zero";
            }

            int zeroesToPad = (numStr.Length % 3) == 0 ? 0 : 3 - (numStr.Length % 3); //If length is 5, 5 % 3 = 2, so we need to pad 1 zero to the left to make it 6 characters long (xxx.xxx)
            numStr = numStr.PadLeft(numStr.Length + zeroesToPad, '0'); //Add zeros to the left so the string follows the pattern xxx.xxx.xxx...            

            while (i < numStr.Length - 2)
            {
                substringContainsNumbers = false;

                if (numStr[i] != '0')
                {
                    result += DigitToWord(numStr[i] - '0') + "Hundred ";
                    substringContainsNumbers = true;
                }

                if (numStr[i + 1] != '0')
                {
                    result += DoubleDigitToWords(numStr[i + 1] - '0', numStr[i + 2] - '0');
                    substringContainsNumbers = true;
                }
                else if (numStr[i + 2] != '0')
                {
                    result += DigitToWord(numStr[i + 2] - '0');
                    substringContainsNumbers = true;
                }

                if(substringContainsNumbers)
                {
                    result += SubstringToWord(thousandPower);
                }
                
                thousandPower--;
                i += 3;
            }

            return result.Trim();
        }

        private static string DigitToWord(int number)
        {
            switch (number)
            {
                case 1:
                    return "One ";
                case 2:
                    return "Two ";
                case 3:
                    return "Three ";
                case 4:
                    return "Four ";
                case 5:
                    return "Five ";
                case 6:
                    return "Six ";
                case 7:
                    return "Seven ";
                case 8:
                    return "Eight ";
                case 9:
                    return "Nine ";
                default:
                    return "";
            }
        }

        private static string DoubleDigitToWords(int fstDigit, int sndDigit)
        {
            if (fstDigit == 1)
            {
                switch (sndDigit)
                {
                    case 0:
                        return "Ten ";
                    case 1:
                        return "Eleven ";
                    case 2:
                        return "Twelve ";
                    case 3:
                        return "Thirteen ";
                    case 4:
                        return "Fourteen ";
                    case 5:
                        return "Fifteen ";
                    case 6:
                        return "Sixteen ";
                    case 7:
                        return "Seventeen ";
                    case 8:
                        return "Eighteen ";
                    case 9:
                        return "Nineteen ";
                    default:
                        return "";
                }
            }
            else
            {
                string result = string.Empty;

                switch (fstDigit)
                {
                    case 2:
                        result = "Twenty ";
                        break;
                    case 3:
                        result = "Thirty ";
                        break;
                    case 4:
                        result = "Forty ";
                        break;
                    case 5:
                        result = "Fifty ";
                        break;
                    case 6:
                        result = "Sixty ";
                        break;
                    case 7:
                        result = "Seventy ";
                        break;
                    case 8:
                        result = "Eighty ";
                        break;
                    case 9:
                        result = "Ninety ";
                        break;
                    default:
                        break;
                }

                return result + DigitToWord(sndDigit);
            }
        }

        private static string SubstringToWord(int remainingSubstrings)
        {
            switch (remainingSubstrings)
            {
                case 1:
                    return "Thousand ";
                case 2:
                    return "Million ";
                case 3:
                    return "Billion ";
                case 4:
                    return "Trillion ";
                case 5:
                    return "Quatrillion ";
                default:
                    return "";
            }
        }
    }
}
