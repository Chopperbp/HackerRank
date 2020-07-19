using System;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

//https://www.hackerrank.com/contests/hack-the-interview-iv/challenges/maximum-or-1/problem
namespace Challenges.NumberOfIntegers
{
    public class TestsSamples
    {
        private readonly ITestOutputHelper output;
        public TestsSamples(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Theory]
        [InlineData(1, 100, 1, 18)]
        [InlineData(10, 55, 2, 41)]
        [InlineData(1, 99, 3, 0)]
        [InlineData(1, 100, 2, 81)]
        [InlineData(1, 200, 1, 19)]
        [InlineData(1, 200, 2, 99)]
        [InlineData(1, 999, 3, 729)]
        [InlineData(1, 1000, 2, 243)]
        [InlineData(1, 8999, 2, 459)]
        [InlineData(1, 9000, 2, 459)]
        [InlineData(1, 9999, 3, 2916)]
        [InlineData(1, 10000, 3, 2916)]
        [InlineData(1, 47622, 3, 4803)]
        [InlineData(1, 2435, 2, 292)]
        [InlineData(1, 5432, 2, 373)]
        [InlineData(10, 35, 2, 23)]
        [InlineData(100, 400, 2, 54)]
        [InlineData(100, 999, 1, 8)]
        [InlineData(100, 999, 2, 162)]
        [InlineData(100, 999, 3, 729)]
        [InlineData(1000, 2000, 2, 27)]
        [InlineData(1000, 2435, 2, 49)]
        [InlineData(1000, 5431, 1, 4)]
        [InlineData(1000, 5431, 2, 130)]
        [InlineData(1000, 5431, 3, 1119)]
        [InlineData(1000, 5431, 4, 3178)]
        [InlineData(1000, 9000, 2, 216)]
        [InlineData(1000, 9999, 1, 8)]
        [InlineData(1000, 9999, 2, 243)]
        [InlineData(1000, 9999, 3, 2187)]
        [InlineData(1000, 9999, 4, 6561)]
        [InlineData(2000, 2400, 2, 22)]
        [InlineData(2400, 2430, 2, 0)]
        [InlineData(2430, 2435, 2, 0)]
        [InlineData(10000, 49622, 3, 1941)]
        [InlineData(10000, 47622, 3, 1887)]
        // [InlineData(153_461, 457_823_489, 4, 577669)]
        public void Samples(Int64 S, Int64 R, Int64 K, Int64 expected)
        {
            var result = NumberOfIntegersInt.getNumberOfIntegers(S, R, K);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Samples1()
        {
            var start = 1000;
            var sb = new StringBuilder();
            for (int k = 2; k < 3; k++)
            {
                for (int i = 8000; i < 9999; i++)
                {
                    var result = NumberOfIntegersInt.getNumberOfIntegers(start, i, k);
                    var calculated = NumberOfIntegersBigInteger.getNUmberOfIntergerUpper(i.ToString().Select(c => c - '0').ToList(),  k);
                    sb.AppendLine($"{start}-{i}, K:{k}: {result} {calculated}");
                }
            }
            File.WriteAllText("test.txt", sb.ToString());
        }
        [Fact]
        public void SamplesDigitDP()
        {
            NumberOfIntegers.getNumberOfIntegers("1000", "9000", 2);
        }
    }
}
