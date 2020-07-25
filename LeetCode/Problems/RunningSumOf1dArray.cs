using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode.Problems
{
    public class RunningSumOf1dArray
    {
        public int[] RunningSum(int[] nums)
        {
            return nums.Aggregate(new List<int>(), (acc, next) =>
            {
                acc.Add(acc.LastOrDefault() + next);
                return acc;
            }).ToArray();
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 3, 6, 10 })]
        public void Test(int[] actual, int[] expected)
        {
            Assert.Equal(expected, RunningSum(actual));
        }
    }
}
