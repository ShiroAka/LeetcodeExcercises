using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeExcercises
{
    static class NumberLineJumps
    {
        public static string kangaroo(int x1, int v1, int x2, int v2)
        {
            //The kangaroos MUST end at the same position after 'n' jumps
            //
            //      endPosition = x1 + jumps * v1 = x2 + jumps * v2
            //      jumps = (x2 - x1) / (v1 - v2)
            // 
            //The number of jumps has to be an integer value (no decimals), and it has to be positive (> 0)
            //Otherwise, the kangaroos will never be able to meet after 'n' jumps

            double requiredJumps = (double)(x2 - x1) / (v1 - v2);  

            if ((requiredJumps > 0) && ((requiredJumps % 1) == 0))
            {
                return "YES";
            }
            else
            {
                return "NO";
            }
        }

        private static void TestCase(int x1, int v1, int x2, int v2)
        {
            Console.WriteLine("Kangaroo 1 --> Initial Position (x1): {0}; Jump Distance (v1): {1}", x1, v1);
            Console.WriteLine("Kangaroo 2 --> Initial Position (x2): {0}; Jump Distance (v2): {1}", x2, v2);
            Console.WriteLine("\nCan they meet at the same spot after the same amount of jumps?");

            Console.WriteLine(kangaroo(x1, v1, x2, v2) + "\n\n");
            Console.WriteLine("==================================");
        }

        public static void RunExercise()
        {
            TestCase(0, 3, 4, 2);
            TestCase(0, 2, 5, 3);
            TestCase(23, 9867, 9814, 5861);
        }
    }
}
