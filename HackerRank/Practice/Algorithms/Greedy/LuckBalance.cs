using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HackerRank.Algorithms.Greedy
{
    public class LuckBalance
    {
        // Complete the luckBalance function below.
        static int luckBalance(int k, int[][] contests)
        {
            var luck = 0;
            var important = contests.Where(a => a[1] == 1).Select(a => a[0]).OrderByDescending(a=>a);
            luck += contests.Where(a => a[1] == 0).Sum(a => a[0]);
            luck += important.Take(k).Sum();
            luck -= important.Skip(k).Sum();
            return luck;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Test(int[][] actual, int k, int expected)
        {
            Assert.Equal(expected, luckBalance(k, actual));
        }


        public static IEnumerable<object[]> Data =>
            new List<(int[][] input, int k, int expected)>
            {
                (input: new int[][]{
                    new int[] {5, 1 },
                    new int[] {2, 1 },
                    new int[] {1, 1 },
                    new int[] {8, 1 },
                    new int[]{10, 0 },
                    new int[]{5, 0}
                    },
                 k:3,
                 expected:29)
            }.Select(i => new object[] { i.input, i.k, i.expected });
    }
}
