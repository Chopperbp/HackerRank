using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Common
{
    public class CommonTest
    {
        [Theory]
        [InlineData(new char[] { 'a', 'b', 'c', 'd', 'e' }, 2, 0, new char[] { 'a', 'b' })]
        [InlineData(new char[] { 'a', 'b', 'c', 'd', 'e' }, 2, 9, new char[] { 'd', 'e' })]
        [InlineData(new char[] { 'a', 'b', 'c', 'd', 'e' }, 3, 8, new char[] { 'b', 'd', 'e' })]
        [InlineData(new char[] { 'a', 'b', 'c', 'd', 'e' }, 4, 4, new char[] { 'b', 'c', 'd', 'e' })]
        public void TestCombinationFromIndex(char[] arr, int k, int ind, char[] expected)
        {
            Assert.Equal(expected, Common.CombinationFromIndex<char>(arr, k, ind));
          
        }
        [Fact]
        public void CombinationFromIndexAll()
        {
            var result = new List<string>();
            for (int i = 0; i < 15; i++)
            {
                result.Add(new string (Common.CombinationFromIndex<char>(new char[] { 'a', 'b', 'c','d','e', 'f' }, 4, i)));
            }
        }
        [Fact]
        public void CombinationsRosettaWoRecursion()
        {
            var result = Common.CombinationsRosettaWoRecursion(2, 5).ToList();
        }
    }
}
