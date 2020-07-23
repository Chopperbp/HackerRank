using System;
using System.Linq;
using System.Numerics;
using Xunit;

namespace HackerRank.Algorithms.Greedy
{
    public class MaximumPerimeterTriangle
    {
        // Complete the maximumPerimeterTriangle function below.
        static int[] maximumPerimeterTriangle(int[] sticks)
        {
            var ordered = sticks.OrderByDescending(a => a).ToArray();
            var comb = Combination(ordered.Count(), 3);
            var hasMatch = false;
            for (int i = 0; i < comb && !hasMatch; i++)
            {
                var triangele = CombinationFromIndex(ordered, 3, i);
                if (isTriangle(triangele))
                {
                    Array.Sort(triangele);
                    return triangele;
                }
            }
            return new int[] { -1 };
        }
        public static T[] CombinationFromIndex<T>(T[] arr, int k, int ind)
        {
            var n = arr.Length;
            var indexies = new int[k];
            for (int i = 0; i < k; i++)
            {
                int j = 0;
                int prevIndex = i > 0 ? indexies[i - 1] + 1 : 0;
                BigInteger sum = 0;
                BigInteger comb = 0;
                while (ind >= sum + comb)
                {
                    sum += comb;
                    comb = Combination(n - prevIndex - j - 1, k - i - 1);
                    j++;
                }
                indexies[i] = prevIndex + j - 1;
                ind -= (int)sum;
            }
            indexies[k - 1] += ind;
            return FromIndexies(arr, indexies);
        }
        public static T[] FromIndexies<T>(T[] arr, int[] indexies)
        {
            return indexies.Select(i => arr[i]).ToArray();
        }
        public static BigInteger Combination(int n, int k)
        {
            if (k < 0 || n < 0)
            {
                throw new InvalidOperationException("Please provide positive integers.");
            }
            if (k > n)
            {
                throw new InvalidOperationException("k needs to be smaller than n.");
                //return 0;
            }
            if (k == 0 || n == k)
                return 1;
            if (k == 1)
                return n;

            if (k > n / 2)
            {
                k = n - k;
            }
            BigInteger a = 1;
            BigInteger b = 1;
            for (int i = n - (k - 1); i <= n; i++)
            {
                a *= i;
            }
            for (int i = 1; i <= k; i++)
            {
                b *= i;
            }
            return a / b;
        }
        static bool isTriangle(int[] sticks)
        {
            return sticks[0] + sticks[1] > sticks[2] && sticks[0] + sticks[2] > sticks[1] && sticks[1] + sticks[2] > sticks[0];
        }
        [Theory]
        [InlineData(new int[] { 1, 1, 1, 2, 3, 5 }, new int[] { 1, 1, 1 })]
        [InlineData(new int[] { 1, 1, 1, 3, 3 }, new int[] { 1, 3, 3 })]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { -1 })]
        public void Test(int[] actual, int[] expected)
        {
            Assert.Equal(expected, maximumPerimeterTriangle(actual));
        }
    }
}
