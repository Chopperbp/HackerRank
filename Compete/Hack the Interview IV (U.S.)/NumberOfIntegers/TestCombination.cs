using System;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

//https://www.hackerrank.com/contests/hack-the-interview-iv/challenges/maximum-or-1/problem
namespace Challenges.NumberOfIntegers
{
    public class TestCombination
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void TestCombinations(int n, int k, BigInteger expected)
        {
            var result = NumberOfIntegersBigInteger.Combination(n, k);
            Assert.Equal(expected, result);
        }
        public static IEnumerable<object[]> Data =>
            new List<(int, int, BigInteger)>
            {
                (0, 0, 1),
                (5, 0, 1),
                (5, 1, 5),
                (5, 2, 10),
                (5, 3, 10),
                (5, 4, 5),
                (5, 5, 1),
                (10, 0, 1),
                (10, 1, 10),
                (10, 10, 1),
                (10, 4, 210),
                (10, 5, 252),
                (10, 6, 210),
                (100,50, BigInteger.Parse("100891344545564193334812497256"))
            }.ConvertAll(d => new object[] { d.Item1, d.Item2, d.Item3 });

        [Fact]
        public void TestCombinationMargin()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => NumberOfIntegersBigInteger.Combination(-1, 0));
            Assert.Equal("Please provide positive integers.", ex.Message);
            var ex1 = Assert.Throws<InvalidOperationException>(() => NumberOfIntegersBigInteger.Combination(10, 11));
            Assert.Equal("k needs to be smaller than n.", ex1.Message);
        }
    }
}
