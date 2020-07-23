using Common;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace HackerRank.Algorithms.Warmup
{
    public class PlusMinus
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public PlusMinus(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

        }
        // Complete the plusMinus function below.
        static void plusMinus(int[] arr)
        {
            var (plus, minus, zero) = (0, 0, 0);
            foreach (var item in arr)
            {
                if (item < 0)
                    minus++;
                else if (item > 0)
                    plus++;
                else
                    zero++;
            }
            Console.WriteLine(((decimal)plus / arr.Length).ToString("F6"));
            Console.WriteLine(((decimal)minus / arr.Length).ToString("F6"));
            Console.WriteLine(((decimal)zero / arr.Length).ToString("F6"));
        }

        [Theory]
        [InlineData(new int[] { -4, 3, -9, 0, 4, 1 }, new string[] { "0.500000", "0.333333", "0.166667" })]
        public void Test(int[] actual, string[] expected)
        {
            plusMinus(actual);
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
