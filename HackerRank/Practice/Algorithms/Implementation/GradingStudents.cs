using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HackerRank.Algorithms.Implementation
{
    public class GradingStudents
    {
        public static List<int> gradingStudents(List<int> grades)
        {
            return grades.Select(g =>
            {
                var next = g + (5 - (g % 5));
                return (g >= 38 && next - g < 3) ? next : g;
            }).ToList();
        }

        [Theory]
        [InlineData(new int[] { 73, 67, 38, 33 }, new int[] { 75, 67, 40, 33 })]
        public void Test(int[] actual, int[] expected)
        {
            Assert.Equal(expected.ToList(), gradingStudents(actual.ToList()));
        }
    }
}
