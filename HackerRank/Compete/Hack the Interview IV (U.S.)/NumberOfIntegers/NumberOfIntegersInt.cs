using System;
using System.Collections.Generic;
using System.Linq;

namespace HacerRank.Compete.NumberOfIntegers
{
    public class NumberOfIntegersInt
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
        public static int getNumberOfIntegers(Int64 L, Int64 R, Int64 K)
        {
            var result = new List<Int64>();
            for (Int64 i = L + 1; i <= R; i++)
            {
                if (i.ToString().Count(c => c != '0') == K)
                {
                    result.Add(i);
                    Console.WriteLine(i);
                }
            }
            return result.Count;
        }
    }
}
