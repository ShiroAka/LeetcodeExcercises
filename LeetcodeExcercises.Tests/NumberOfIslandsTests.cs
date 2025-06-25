
using FluentAssertions;

namespace LeetcodeExcercises.Tests
{
    public class NumberOfIslandsTests
    {
        [Fact]
        public void BasicTest()
        {
            char[][] grid = new char[][]
            {
                new[] { '1', '1', '1', '1', '0' },
                new[] { '1', '1', '0', '1', '0'},
                new[] { '1', '1', '0', '0', '0' },
                new[] {'0', '0', '0', '0', '0' }
            };

            Console.WriteLine("Starting grid:\n[");

            for (int i = 0; i < grid.Length; i++)
            {
                bool first = true;

                Console.Write("  ");

                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (first)
                    {
                        Console.Write("{0}", grid[i][j]);
                        first = false;
                    }
                    else
                    {
                        Console.Write(", {0}", grid[i][j]);
                    }
                }

                Console.Write("\n");
            }

            Console.WriteLine("]");

            int numberOfIslands = NumberOfIslands.NumIslands(grid);
            Console.WriteLine("Number of islands in grid = {0}", numberOfIslands);

            numberOfIslands.Should().Be(1, "There is only one island in the grid!.");
        }
    }
}