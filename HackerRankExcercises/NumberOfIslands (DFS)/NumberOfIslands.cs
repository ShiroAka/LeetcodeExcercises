using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeExcercises
{
    public class NumberOfIslands
    {
        private static bool[][] visited;

        public static int NumIslands(char[][] grid)
        {
            int count = 0;
            visited = new bool[grid.Length][];

            for (int i = 0; i < grid.Length; i++)
            {
                visited[i] = new bool[grid[0].Length];
            }

            for (int i = 0; i < grid.Length; i++) //Rows
            {
                for (int j = 0; j < grid[0].Length; j++) //Columns
                {
                    if (!visited[i][j] && grid[i][j] == '1')
                    {
                        count++;
                        DepthFirstSearch(i, j, grid);
                    }
                }
            }

            return count;
        }

        private static void DepthFirstSearch(int row, int col, char[][] grid)
        {
            if (row < 0 || col < 0 || row >= grid.Length || col >= grid[0].Length)
                return;

            if (visited[row][col] || grid[row][col] == '0')
                return;

            visited[row][col] = true;

            //This goes first through all the first column until it reaches the end or finds a '0'.
            //Then, for the last step before the edge/zero, it does the other steps (moves up in the column, then right inside the row, then left)
            DepthFirstSearch(row + 1, col, grid);
            DepthFirstSearch(row - 1, col, grid);
            DepthFirstSearch(row, col + 1, grid);
            DepthFirstSearch(row, col - 1, grid);
        }
    }
}
