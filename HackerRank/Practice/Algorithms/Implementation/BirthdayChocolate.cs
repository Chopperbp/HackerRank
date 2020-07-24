using BenchmarkDotNet.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HackerRank.Algorithms.Implementation
{
    public class BirthdayChocolate
    {
        static int birthday(List<int> s, int d, int m)
        {
            var result = 0;
            for (int i = 0; i <= s.Count() - m; i++)
            {
                var sum = 0;
                for (int j = i; j < i + m; j++)
                {
                    sum += s[j];
                }
                if (sum == d)
                {
                    result++;
                }
            }
            return result;
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 1, 3, 2 }, 3, 2, 2)]
        [InlineData(new int[] { 1, 1, 1, 1, 1, 1 }, 3, 2, 0)]
        [InlineData(new int[] { 4 }, 4, 1, 1)]
        public void Test(int[] s, int d, int m, int expected)
        {
            Assert.Equal(expected, birthday(s.ToList(), d, m));
        }
    }
}
