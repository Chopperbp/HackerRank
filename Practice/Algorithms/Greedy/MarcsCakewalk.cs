using System;
using Xunit;

namespace Greedy
{
    public class MarcsCakewalk
    {
        public static long IntPower(int x, short power)
        {
            if (power == 0) return 1;
            if (power == 1) return x;
            // ----------------------
            int n = 15;
            while ((power <<= 1) >= 0) n--;

            long tmp = x;
            while (--n > 0)
                tmp = tmp * tmp * (((power <<= 1) < 0) ? x : 1);
            return tmp;
        }
        // Complete the marcsCakewalk function below.
        static long marcsCakewalk(int[] calorie)
        {
            Array.Sort(calorie);
            Array.Reverse(calorie);
            long result = 0;
            for (short i = 0; i < calorie.Length; i++)
            {
                result+= IntPower(2, i) * calorie[i];
            }
            return result;
        }


        [Theory]
        [InlineData(new int[] { 7, 4, 9, 6 }, 79)]
        [InlineData(new int[] { 1, 3, 2 }, 11)]
        public void Test(int[] actual, long expected)
        {
            Assert.Equal(expected, marcsCakewalk(actual));
        }
    }
}
