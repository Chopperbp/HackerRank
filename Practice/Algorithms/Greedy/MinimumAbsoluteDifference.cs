using System;
using Xunit;

namespace Greedy
{
    public class MinimumAbsoluteDifference
    {
        static int minimumAbsoluteDifference(int[] arr)
        {
            var min = int.MaxValue;
            Array.Sort(arr);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var dif = Math.Abs(arr[i] - arr[i + 1]);
                if (dif < min)
                    min = dif;
            }
            return min;
        }

        [Theory]
        [InlineData(new int[] { 3, -7, 0 }, 3)]
        [InlineData(new int[] { -59, -36, -13, 1, -53, -92, -2, -96, -54, 75 }, 1)]
        [InlineData(new int[] { 1, -3, 71, 68, 17 }, 3)]
        public void Test(int[] actual, int expected)
        {
            Assert.Equal(expected, minimumAbsoluteDifference(actual));
        }
    }
}
