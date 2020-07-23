using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HackerRank.Algorithms.Implementation
{
    public class BetweenTwoSets
    {
        // Complete the kangaroo function below.
        public static int getTotalX(List<int> a, List<int> b)
        {
            var lcm = LeastCommonMultiple(a.ToArray());
            var gcd = GCD(b.ToArray());
            // solution 1 
            /* 
             var count = 0;
             for (int i = 1; i <= gcd / lcm; i++)
            {
                if (gcd % (lcm * i) == 0) count++;
            }
            return count;
            */
            // solution 2
            //return Enumerable.Range(1, gcd / lcm).Aggregate(0, (acc, next) => gcd % (lcm * next) == 0 ? ++acc : acc);
            //solution 3
            var result = Enumerable
                .Range(1, gcd / lcm)
                .Select(i => lcm * i)
                .Where(i => gcd % (i) == 0);
            return result.Count();
        }
        public static int LeastCommonMultiple(int[] numbers)
        {
            return numbers.Aggregate(LeastCommonMultiple);
        }
        public static int LeastCommonMultiple(int a, int b)
        {
            (a, b) = a > b ? (a, b) : (b, a);
            for (int i = 1; i < b; i++)
            {
                if ((a * i) % b == 0)
                {
                    return i * a;
                }
            }
            return a * b;
        }
        public static int GCD(int[] numbers)
        {
            return numbers.Aggregate(GCD);
        }
        public static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return a == 0 ? b : a;
        }

        [Theory]
        [InlineData(new int[] { 2, 4 }, new int[] { 16, 32, 96 }, 3)]
        [InlineData(new int[] { 2, 6 }, new int[] { 24, 36 }, 2)]
        public void Test(int[] a, int[] b, int expected)
        {
            Assert.Equal(expected, getTotalX(a.ToList(), b.ToList()));
        }
    }
}
