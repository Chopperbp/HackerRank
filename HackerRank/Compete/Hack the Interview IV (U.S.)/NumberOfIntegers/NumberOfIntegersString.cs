using System;

namespace HacerRank.Compete.NumberOfIntegers
{
    public class NumberOfIntegersString
    {
        public static int getNumberOfIntegers(string L, string R, int K)
        {
            var result = 0;
            var l = new StringInteger(L);
            l.Increment();
            do
            {
                if (l.GetNonZeroNumbers() == K)
                {
                    result++;
                }
                l.Increment();
            } while (String.Compare(l.ToString().PadLeft(R.Length, '0'), R) <= 0);
            return result % 1000000007;
        }
    }
}
