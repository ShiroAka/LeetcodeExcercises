using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeExcercises
{
    static class Staircase
    {
        //Function made by me
        static void staircase(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                //Print Spaces
                for (int j = 0; j < n - i; j++)
                    Console.Write(' ');

                //Print Sharps
                for (int k = 0; k < i; k++)
                    Console.Write('#');

                Console.WriteLine();
            }
        }
                
        static void RunExercise()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            staircase(n);
        }
    }
}
