using System;
using Xunit;

namespace HackerRank.Algorithms.Warmup
{
    public class TimeConversion
    {
        static string timeConversion(string s)
        {
            var hours = Convert.ToInt32(s.Substring(0, 2));
            var midday = s.Substring(8, 2);
            int hours24;
            if (midday == "AM")
                hours24 = hours == 12 ? 0 : hours;
            else
                hours24 = hours == 12 ? 12 : hours + 12;
            var result = hours24.ToString("D2") + s.Substring(2, 6);
            return result;
        }

        [Theory]
        [InlineData("07:05:45PM", "19:05:45")]
        [InlineData("12:40:22AM", "00:40:22")]
        
        public void Test(string actual, string expected)
        {
            Assert.Equal(expected, timeConversion(actual));
        }
    }
}
