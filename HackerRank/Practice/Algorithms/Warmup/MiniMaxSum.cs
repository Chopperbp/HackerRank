using Common;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace HackerRank.Algorithms.Warmup
{
    public class MiniMaxSum
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public MiniMaxSum(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

        }
        static void miniMaxSum(int[] arr)
        {
            var min = arr.OrderBy(a => a).Take(arr.Length - 1).Sum(x => (long)x);
            var max = arr.OrderByDescending(a => a).Take(arr.Length - 1).Sum(x => (long)x);
            Console.WriteLine($"{min} {max}");
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, new string[] { "10 14" })]
        public void Test(int[] actual, string[] expected)
        {
            miniMaxSum(actual);
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
