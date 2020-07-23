using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HackerRank.Algorithms.Implementation
{
    public class ApplesAndOranges
    {
        static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            Console.WriteLine($"{apples.Aggregate(0, (acc, next) => next + a >= s && next + a <= t ? ++acc : acc)}");
            Console.WriteLine($"{oranges.Aggregate(0, (acc, next) => next + b >= s && next + b <= t ? ++acc : acc)}");

        }

        [Theory]
        [InlineData(7, 11, 5, 15, new int[] { -2, 2, 1 }, new int[] { 5, -6 }, new string[] { "1", "1" })]
        [InlineData(2, 3, 1, 5, new int[] { 2 }, new int[] { -2 }, new string[] { "1", "1" })]
        public void Test(int s, int t, int a, int b, int[] apples, int[] oranges, string[] expected)
        {
            countApplesAndOranges(s, t, a, b, apples, oranges);
            Assert.Equal(expected, Console.Output);
        }

        public class Console
        {
            public static List<string> Output { get; } = new List<string>();
            public static void WriteLine(string s)
            {
                Output.Add(s);
            }
        }
    }
}
