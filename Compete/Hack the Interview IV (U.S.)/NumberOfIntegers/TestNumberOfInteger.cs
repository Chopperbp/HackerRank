using Xunit;

//https://www.hackerrank.com/contests/hack-the-interview-iv/challenges/maximum-or-1/problem
namespace Challenges.NumberOfIntegers
{
    public class TestNumberOfInteger
    {
        [Theory]
        [InlineData(5431, 2, 373)]
        [InlineData(9000, 2, 459)]
        [InlineData(8999, 2, 459)]
        public void TestNumberOfIntegerOk(int n, int k, int expected)
        {
            Assert.Equal(expected, NumberOfIntegersBigInteger.getNumberOfInteger(n, k));
        }
    }
}
