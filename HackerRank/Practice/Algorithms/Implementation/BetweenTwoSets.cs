using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HackerRank.Algorithms.Implementation
{
    public class BetweenTwoSets
    {
        public static int getTotalX(List<int> a, List<int> b)
        {
            var gcd = GCD(b.ToArray());
            var lcm = LCM(a.ToArray());
            var count = 0;
            for (int i = 1; i <= gcd / lcm; i++)
            {
                if (gcd % (lcm * i) == 0) count++;
            }
            return count;
        }

        // Complete the kangaroo function below.
        //This solution is bad because lcm has oveflow lcm value is -2045821760
        public static int getTotalXBad(List<int> a, List<int> b)
        {
            var gcd = GCD(b.ToArray());
            var lcm = LeastCommonMultiple(a.ToArray());
            var count = 0;
            for (int i = 1; i <= gcd / lcm; i++)
            {
                if (gcd % (lcm * i) == 0) count++;
            }
            return count;
        }
        //Not slow, OverflowException occured by LCM, because the LCM 
        //When A = 100,... and B= 1,... then LCM 3_115_855_702_159_200 and GCD = 1 and int.max = 2_147_483_647
        //LongMax = 9_223_372_036_854_775_807
        public static int getTotalXSlow(List<int> a, List<int> b)
        {
            var lcm = LCM(a.ToArray());
            var gcd = GCD(b.ToArray());
            var count = 0;
            for (int i = 1; i <= gcd / lcm; i++)
            {
                if (gcd % (lcm * i) == 0) count++;
            }
            return count;
        }
        public static int getTotalXRange(List<int> a, List<int> b)
        {
            var lcm = LeastCommonMultiple(a.ToArray());
            var gcd = GCD(b.ToArray());
            return Enumerable.Range(1, (int)(gcd / lcm)).Aggregate(0, (acc, next) => gcd % (lcm * next) == 0 ? ++acc : acc);
        }
        public static int getTotalXListCount(List<int> a, List<int> b)
        {
            var lcm = LeastCommonMultiple(a.ToArray());
            var gcd = GCD(b.ToArray());
            var result = Enumerable
                .Range(1, (int)(gcd / lcm))
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
            checked
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
        }

        public static long LCM(long a, long b)
        {
            checked
            {
                return a * b / GCD(a, b);
            }
        }
        public static int LCM(int a, int b)
        {
            checked
            {
                return a * b / GCD(a, b);
            }
        }
        public static long LCM(int[] numbers)
        {
            return numbers.Aggregate((long)numbers[0], (acc, next) => LCM(acc, next));
        }
        public static long GCD(int[] numbers)
        {
            return numbers.Aggregate((long)numbers[0], (acc, next) => GCD(acc, next));
        }

        public static int GCD(int a, int b)
        {
            checked
            {
                return (int)GCD((long)a, (long)b);
            }
        }
        public static long GCD(long a, long b)
        {
            checked
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
        }

        [Theory]
        [InlineData(new int[] { 2, 4 }, new int[] { 16, 32, 96 }, 3)]
        [InlineData(new int[] { 2, 6 }, new int[] { 24, 36 }, 2)]
        [InlineData(new int[] { 100, 99, 98, 97, 96, 95, 94, 93, 92, 91 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0)]
        public void Test(int[] a, int[] b, int expected)
        {
            Assert.Equal(expected, getTotalX(a.ToList(), b.ToList()));
        }

        [Theory]
        [InlineData(new int[] { 2, 4 }, new int[] { 16, 32, 96 }, 3)]
        [InlineData(new int[] { 2, 6 }, new int[] { 24, 36 }, 2)]
        [InlineData(new int[] { 100, 99, 98, 97, 96, 95, 94, 93, 92, 91 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0)]
        public void TestSlow(int[] a, int[] b, int expected)
        {
            Assert.Equal(expected, getTotalXSlow(a.ToList(), b.ToList()));
        }
    }
}
