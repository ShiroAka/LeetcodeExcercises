using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeExcercises
{
    static class AppleAndOrange
    {
        public static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
        {
            int appleTreeMinDistance = s - a;
            int appleTreeMaxDistance = t - a;


            //Fruits that fall to the left have a negative value, and the oranges MUST fall to
            //the left to land on the house, so I have to subtract the 'x' positions of the house edges
            //to the orange tree's position to get the range

            int orangeTreeMinDistance = s - b; //The most negative value of both; s = left house edge
            int orangeTreeMaxDistance = t - b;


            int applesThatFellInHouse = CountElementsInRange(apples, appleTreeMinDistance, appleTreeMaxDistance);
            int orangesThatFellInHouse = CountElementsInRange(oranges, orangeTreeMinDistance, orangeTreeMaxDistance);

            Console.WriteLine(applesThatFellInHouse);
            Console.WriteLine(orangesThatFellInHouse);

        }

        private static int CountElementsInRange(List<int> elements, int min, int max)
        {
            int count = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (min <= elements[i] && elements[i] <= max)
                {
                    count++;
                }
            }

            return count;
        }

        public static void RunExercise()
        {
            int s = 7, t = 11; //House min/max edges
            int a = 5, b = 15; //Apple/orange tree positions
            int m = 3, n = 2; //Number of apples/oranges

            List<int> appleFallDistances = new List<int>{ -2, 2, 1 };
            List<int> orangeFallDistances = new List<int> { 5, -6 };

            countApplesAndOranges(s, t, a, b, appleFallDistances, orangeFallDistances);
        }
    }
}
