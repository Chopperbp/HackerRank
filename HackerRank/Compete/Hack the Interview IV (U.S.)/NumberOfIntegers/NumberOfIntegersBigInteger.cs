using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace HacerRank.Compete.NumberOfIntegers
{
    public class NumberOfIntegersBigInteger
    {
        /*
         * Complete the 'getNumberOfIntegers' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. STRING L
         *  2. STRING R
         *  3. INTEGER K
         */
        public static int getNumberOfIntegers(string L, string R, int K)
        {
            BigInteger l = BigInteger.Parse(L.TrimStart('0'));
            BigInteger r = BigInteger.Parse(R.TrimStart('0'));
            var result = getNumberOfInteger(r, K) - getNumberOfInteger(l, K);
            return (int)(result % (BigInteger.Pow(10, 9) + 7));
        }
        public static BigInteger Nearest(BigInteger L, int K)
        {
            var k = 0;
            var origCount = L.ToString().Count();
            do
            {
                var digits = L.ToString();
                if (digits.Count(c => c != '0') >= K || digits.Count() != origCount || digits.Count() < K)
                    return L;
                L--;
            } while (k < K);
            throw new InvalidOperationException("Not found nearest number");
        }
        public static BigInteger getNumberOfInteger(BigInteger L, int K)
        {
            var digits = L.ToString().Select(c => c - '0').ToList();
            var digitsCount = digits.Count;
            if (K > digitsCount)
                return 0;
            BigInteger under = getNumberOfIntegerUnder(digitsCount, K);
            BigInteger upper = getNUmberOfIntergerUpper(digits, K);
            return under + upper;
        }

        public static BigInteger getNUmberOfIntergerUpper(List<int> digits, int K)
        {
            var digitsCount = digits.Count;
            BigInteger upper = 0;
            for (int i = 1; i <= K - 1; i++)
            {
                var partialresult = (Combination(digitsCount - i, K - i) * digits[i - 1] - Combination(digitsCount - (i + 1), K - (i + 1))) * BigInteger.Pow(9, K - i);
                upper += partialresult;
            }
            upper += digits[K - 1];
            return upper;
        }

        public static BigInteger getNumberOfIntegerUnder(int digitsCount, int K)
        {
            BigInteger under = 0;
            if (digitsCount > K)
            {
                for (int i = K - 1; i < digitsCount - 1; i++)
                {
                    under += Combination(i, K - 1);
                }
                under *= BigInteger.Pow(9, K);
            }

            return under;
        }

        public static BigInteger Combination(int n, int k)
        {
            if (k < 0 || n < 0)
            {
                throw new InvalidOperationException("Please provide positive integers.");
            }
            if (k > n)
            {
                throw new InvalidOperationException("k needs to be smaller than n.");
                //return 0;
            }
            if (k == 0 || n == k)
                return 1;
            if (k == 1)
                return n;

            if (k > n / 2)
            {
                k = n - k;
            }
            BigInteger a = 1;
            BigInteger b = 1;
            for (int i = n - (k - 1); i <= n; i++)
            {
                a *= i;
            }
            for (int i = 1; i <= k; i++)
            {
                b *= i;
            }
            return a / b;
        }
    }
}
