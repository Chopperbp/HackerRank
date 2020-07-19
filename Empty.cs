using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class Empty
    {
        [Theory]
        [InlineData("Hello World", "Hello World")]
        [InlineData(TestCase1Input, TestCase1Expected)]
        public void Test(string actual, string expected)
        {
            Assert.Equal(expected, actual);
        }

        const string TestCase1Input = "Hello Világ";
        const string TestCase1Expected = "Hello Világ";
    }
}
