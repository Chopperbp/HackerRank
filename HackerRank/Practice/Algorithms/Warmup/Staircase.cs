using Common;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace HackerRank.Algorithms.Warmup
{
    public class Staircase
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public Staircase(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

        }
        // Complete the staircase function below.
        static void staircase(int n)
        {
            for (int i = n-1; i >= 0; i--)
            {
                Console.WriteLine("".PadLeft(i, ' ').PadRight(n, '#'));
            }

        }

        [Theory]
        [InlineData(4, new string[] { "   #", "  ##", " ###", "####" })]
        public void Test(int actual, string[] expected)
        {
            staircase(actual);
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
