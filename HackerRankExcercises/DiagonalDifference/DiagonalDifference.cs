using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace LeetcodeExcercises
{
    static class DiagonalDifference
    {

        /*
         * Complete the 'diagonalDifference' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */

        public static int diagonalDifference(List<List<int>> arr, int range)
        {
            //This code an the methods used here were made by me

            int j = 0;
            Func<int, int> _operator = AddOne;
            int[] result = { 0, 0 };

            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < range; i++)
                {
                    result[k] += arr[i][j];
                    j = _operator(j);
                }

                j = range - 1;
                _operator = SubtractOne;
            }

            return Math.Abs(result[0] - result[1]);
        }

        public static int AddOne(int num)
        {
            return num + 1;
        }

        public static int SubtractOne(int num)
        {
            return num - 1;
        }


        //This method was provided by the HackerRank page
        public static void RunExcercise()
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> arr = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            }

            int result = diagonalDifference(arr, n);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}