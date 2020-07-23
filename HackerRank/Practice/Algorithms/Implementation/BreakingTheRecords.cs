using System.Linq;
using Xunit;

namespace HackerRank.Algorithms.Implementation
{
    public class BreakingTheRecords
    {
        // Complete the breakingRecords function below.
        static int[] breakingRecords(int[] scores)
        {
            return new int[]
            {
                scores.Aggregate((max:int.MinValue, result:0), (acc,next)=> next > acc.max ? (next,++acc.result):acc, acc=>acc.result-1),
                scores.Aggregate((min:int.MaxValue, result:0), (acc,next)=> next < acc.min ? (next,++acc.result):acc, acc=>acc.result-1),
            };
        }

        [Theory]
        [InlineData(new int[] { 3, 4, 21, 36, 10, 28, 35, 5, 24, 42 }, new int[] { 4, 0 })]
        [InlineData(new int[] { 10, 5, 20, 20, 4, 5, 2, 25, 1 }, new int[] { 2, 4 })]
        [InlineData(new int[] { 0, 9, 3, 10, 2, 20 }, new int[] { 3, 0 })]

        public void Test(int[] scores, int[] expected)
        {
            Assert.Equal(expected, breakingRecords(scores));
        }
    }
}
