using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HackerRank.Algorithms.Warmup
{
    public class DiagonalDifference
    {
        public static int diagonalDifference(List<List<int>> arr)
        {
            var ltr = 0;
            var rtl = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                ltr += arr[i][i];
                rtl += arr[i][arr.Count - 1 - i];
            }
            return Math.Abs(ltr - rtl);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Test(List<List<int>> actual, int expected)
        {
            Assert.Equal(expected, diagonalDifference(actual));
        }

        public static IEnumerable<object[]> Data =>
            new List<(List<List<int>> input, int expected)>
            {
                (input: new List<List<int>>{ new List<int> {11,2,4 }, new List<int> {4,5,6 }, new List<int> {10,8,-12 }},
                 expected:15)
            }.Select(i => new object[] { i.input, i.expected });
    }
}
