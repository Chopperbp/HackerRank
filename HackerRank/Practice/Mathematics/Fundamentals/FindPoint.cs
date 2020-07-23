using Xunit;

namespace HackerRank.Mathematics.Fundamentals
{
    // https://www.hackerrank.com/challenges/find-point/problem
    public class FindPoint
    {
        static int[] findPoint(int px, int py, int qx, int qy)
        {
            /*
             * Write your code here.
             */
            return new int[] { 2 * qx - px, 2 * qy - py };
        }
        [Theory]
        [InlineData(new int[] { 0, 0, 1, 1 }, new int[] { 2, 2 })]
        [InlineData(new int[] { 1, 1, 2, 2 }, new int[] { 3, 3 })]
        public void Test(int[] actual, int[] expected)
        {

            Assert.Equal(expected, findPoint(actual[0], actual[1], actual[2], actual[3]));
        }
    }
}
