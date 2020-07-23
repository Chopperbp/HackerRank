using Xunit;
//https://www.hackerrank.com/challenges/maximum-draws/problem
namespace HackerRank.Mathematics.Fundamentals
{
    public class MaximumDraws
    {
        /*
         * Complete the maximumDraws function below.
         */
        static int maximumDraws(int n)
        {
            /*
             * Write your code here.
             */
            return n + 1;
        }
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(203624, 203625)]
        public void Test(int actual, int expected)
        {

            Assert.Equal(expected, maximumDraws(actual));
        }
    }
}
