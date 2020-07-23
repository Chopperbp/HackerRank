using System.Linq;
using Xunit;

namespace SampleTest
{
    public class LinqAggregate
    {
        [Theory]
        [InlineData(new int[] { 2, 5, 11, 3, 4 }, 25)]
        public void AggregateSum(int[] actual, int expected)
        {
            var result = actual.Aggregate((acc, next) =>
            {
                return acc + next;
            });
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 2, 5, 11, 3, 4 }, 2)]
        public void AggregateEvenCount(int[] actual, int expected)
        {
            var result = actual.Aggregate(0, (acc, next) =>
             {
                 return acc += next % 2 == 0 ? 1 : 0;
             });
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(new int[] { 2, 5, 11, 3, 4 }, 22)]
        public void AggregateEvenMax(int[] actual, int expected)
        {
            var result = actual.Aggregate(0,
                (max, next) =>
            {
                return next > max ? next : max;
            },
                (acc) =>
                {
                    return acc * 2;
                });
            Assert.Equal(expected, result);
        }

    }
}
