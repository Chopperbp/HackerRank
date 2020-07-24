using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Common
{
    public class CommonTest
    {
        [Theory]
        [InlineData(new char[] { 'a', 'b', 'c', 'd', 'e' }, 2, 0, new char[] { 'a', 'b' })]
        [InlineData(new char[] { 'a', 'b', 'c', 'd', 'e' }, 2, 9, new char[] { 'd', 'e' })]
        [InlineData(new char[] { 'a', 'b', 'c', 'd', 'e' }, 3, 8, new char[] { 'b', 'd', 'e' })]
        [InlineData(new char[] { 'a', 'b', 'c', 'd', 'e' }, 4, 4, new char[] { 'b', 'c', 'd', 'e' })]
        public void TestCombinationFromIndex(char[] arr, int k, int ind, char[] expected)
        {
            Assert.Equal(expected, Common.CombinationFromIndex<char>(arr, k, ind));

        }
        
        [Fact]
        public void CombinationFromIndexAll()
        {
            var result = new List<string>();
            for (int i = 0; i < 15; i++)
            {
                result.Add(new string(Common.CombinationFromIndex<char>(new char[] { 'a', 'b', 'c', 'd', 'e', 'f' }, 4, i)));
            }
        }
        
        [Fact]
        public void CombinationsRosettaWoRecursion()
        {
            var result = Common.CombinationsRosettaWoRecursion(2, 5).ToList();
        }

        [Theory]
        [InlineData(new int[] { 630, 252, 2205 }, 63)]
        public void GCDTest(int[] actual, int expected)
        {
            Assert.Equal(expected, Common.GCD(actual));
        }
        
        [Theory]
        [InlineData(new int[] { 630, 252, 2205 }, 63)]
        public void GCFTest(int[] actual, int expected)
        {
            Assert.Equal(expected, Common.GCF(actual));
        }

        [Theory]
        [Benchmark]
        [InlineData(new int[] { 63, 105, 252 }, 1260)]
        [InlineData(new int[] { 100, 99, 98, 97, 96, 95, 94, 93, 92, 91 }, 3115855702159200)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2520)]
        [Arguments(new int[] { 100, 99, 98, 97, 96, 95, 94, 93, 92, 91 }, 3115855702159200)]
        [Arguments(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2520)]
        public void LCMTest(int[] actual, long expected)
        {
            Assert.Equal(expected, Common.LCM(actual));
        }

        [Theory]
        [Benchmark]
        [InlineData(new int[] { 63, 105, 252 }, 1260)]
        [InlineData(new int[] { 100, 99, 98, 97, 96, 95, 94, 93, 92, 91 }, 3115855702159200)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2520)]
        [Arguments(new int[] { 100,99,98,97,96,95,94,93,92,91 }, 3115855702159200)]
        [Arguments(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2520)]
        public void LeastCommonMultipleTest(int[] actual, long expected)
        {
            Assert.Equal(expected, Common.LeastCommonMultiple(actual));
        }
    }
}
