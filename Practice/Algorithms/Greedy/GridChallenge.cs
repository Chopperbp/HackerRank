using System;
using Xunit;

namespace Greedy
{
    public class GridChallenge
    {
        // Complete the gridChallenge function below.
        static string gridChallenge(string[] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                var row = grid[i].ToCharArray();
                Array.Sort(row);
                grid[i] = new string(row);
            }
            var order = true;
            for (int i = 0; i < grid.Length && order; i++)
            {
                for (int j = 0; j < grid[i].Length - 1 && order; j++)
                {
                    if (grid[i][j + 1] < grid[i][j])
                        order = false;
                }
            }
            for (int i = 0; i < grid.Length - 1 && order; i++)
            {
                for (int j = 0; j < grid[i].Length && order; j++)
                {
                    if (grid[i+1][j] < grid[i][j])
                        order = false;
                }
            }
            return order ? "YES" : "NO";
        }


        [Theory]
        [InlineData(new string[] { "abcde", "fghij", "klmno", "pqrst", "uvwxy" }, "YES")]
        [InlineData(new string[] { "eabcd", "fghij", "olkmn", "trpqs", "xywuv" }, "YES")]
        [InlineData(new string[] { "abc", "lmp", "qrt" }, "YES")]
        [InlineData(new string[] { "mpxz", "abcd", "wlmf" }, "NO")]
        [InlineData(new string[] { "abc", "hjk", "mpq", "rtv" }, "YES")]
        public void Test(string[] actual, string expected)
        {
            Assert.Equal(expected, gridChallenge(actual));
        }
    }
}
