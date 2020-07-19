using System;
using Xunit;

namespace Challenges.NumberOfIntegers
{
    public class StringIntegerTest
    {
        [Fact]
        public void Tests()
        {
            var num = new StringInteger("098");
            Assert.Equal("98", num.ToString());
            num.Increment();
            Assert.Equal("99", num.ToString());
            Assert.Equal(2, num.GetNonZeroNumbers());
            num.Increment();
            Assert.Equal("100", num.ToString());
            Assert.Equal(1, num.GetNonZeroNumbers());
            Assert.True(String.Compare(num.ToString(), "101") < 0);
            Assert.True(String.Compare(num.ToString(), "099") > 0);
        }
    }
}
