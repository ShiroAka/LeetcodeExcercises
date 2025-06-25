using System;
using System.Collections.Generic;

namespace LeetcodeExcercises
{
    /*
     * NOTE: This was an excercise I received after applying to a company called "Varicent", before getting an interview with them.
     * 
     * When thinking about the problem, I thought about the 2nd solution (moveNumbersToCenterV2), but wasn't sure I could implement it in the 30min time limit, so
     * I opted for the first solution.
     * 
     * I knew I could implement a solution that would go through the array only once, while moving each instance of the number 'num' to the center of the array, but I had to 
     * think about it for a while to understand how I could do it (I knew I would have to think how to work with the indexes for it to work with just one iteration through the array).
     */

    /*
     * NOTE 2: The original name for the function was "zeroesToCenter", but I changed it to "moveNumbersToCenter" because the excercise was to move any number to the center 
     * of the array, not just zeros.
     */

    public class MoveNumbersToCenter
    {
        public static List<int> moveNumbersToCenterV1(List<int> arr, int num)
        {
            int numRepetitions = 0;
            List<int> result = new List<int>();

            for(int i = 0; i < arr.Count; i++)
            {
                if (arr[i] == num)
                {
                    numRepetitions++;
                }
                else
                {
                    result.Add(arr[i]);
                }
            }

            int centerIndex = (int)Math.Floor((double)(result.Count / 2));

            for(int i = 0; i < numRepetitions; i++)
            {
                result.Insert(centerIndex, num);
            }

            return result;
        }

        public List<int> moveNumbersToCenterV2(List<int> arr, int num) //
        {
            int centerIndex = (int)Math.Floor((double)(arr.Count / 2));
            int currentIndex = 0;
            int numReps = 0;

            //To understand this it is better to draw an example array in paint (e.g. arr = {1,0,2,0,3,4,0,5,0} ; num = 0) and reproduce each step
            while (currentIndex < arr.Count)
            {
                if (arr[currentIndex] == num)
                {
                    arr.RemoveAt(currentIndex);
                    arr.Insert(centerIndex, currentIndex);
                    numReps++;

                    if (currentIndex > centerIndex)
                    {
                        //When past the center of the array, if I move the current element to the center, at the pos. 'i' (the current one) I will see the element I saw before (in the previous step), so I have 
                        //to move the index to visit a new element in the list
                        currentIndex++;
                    }
                    else if ((currentIndex + numReps) >= centerIndex) // currentIndex <= centerIndex && ...
                    {
                        //If after moving the element to the center the above condition is met, it means the element at the current index and the next ones (up until the center of the array) will be == num, so 
                        //the left part of the array was solved and I only have to solve the right part

                        //arr[centerIndex] will be == num, so I have to start analyzing the right part from the first position past the center of the array				
                        currentIndex = centerIndex + 1;
                    }
                }
                else
                {
                    currentIndex++;
                }
            }

            return arr;
        }
    }
}
