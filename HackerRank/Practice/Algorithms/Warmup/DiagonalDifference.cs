using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HackerRank.Algorithms.Warmup
{
    public class BirthdayCakeCandle
    {
        // Complete the birthdayCakeCandles function below.
        static int birthdayCakeCandles(int[] ar)
        {
            var max = ar.Max();
            return ar.Count(a => a == max);
        }

        [Theory]
        [InlineData(new int[] { 4, 4, 1, 3 }, 2)]
        [InlineData(new int[] { 3, 2, 1, 3 }, 2)]
        public void Test(int[] actual, int expected)
        {
            Assert.Equal(expected, birthdayCakeCandles(actual));
        }


    }
}
