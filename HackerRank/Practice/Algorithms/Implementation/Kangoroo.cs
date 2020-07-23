using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HackerRank.Algorithms.Implementation
{
    public class Kangoroo
    {
        // Complete the kangaroo function below.
        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            if (v2 == v1 && x1 != x2)
                return "NO";
            if (v2 == v1 && x1 == x2)
                return "YES";
            var reminder = (x1 - x2) % (v2 - v1);
            var value = (x1 - x2) / (v2 - v1);
            return value >= 0 && reminder == 0 ? "YES" : "NO";

        }

        [Theory]
        [InlineData(0, 3, 4, 2, "YES")]
        [InlineData(0, 2, 4, 3, "NO")]
        [InlineData(43, 2, 70, 2, "NO")]

        public void Test(int x1, int v1, int x2, int v2, string expected)
        {
            Assert.Equal(expected, kangaroo(x1, v1, x2, v2));
        }
    }
}
