using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace Common
{
    public static class Common
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


        public static T[] CombinationFromIndex<T>(T[] arr, int k, int ind)
        {
            var n = arr.Length;
            var indexies = new int[k];
            for (int i = 0; i < k; i++)
            {
                int j = 0;
                int prevIndex = i > 0 ? indexies[i - 1] + 1 : 0;
                BigInteger sum = 0;
                BigInteger comb = 0;
                while (ind >= sum + comb)
                {
                    sum += comb;
                    comb = Combination(n - prevIndex - j - 1, k - i - 1);
                    j++;
                }
                indexies[i] = prevIndex + j - 1;
                ind -= (int)sum;
            }
            indexies[k - 1] += ind;
            return FromIndexies(arr, indexies);
        }
        public static T[] FromIndexies<T>(T[] arr, int[] indexies)
        {
            return indexies.Select(i => arr[i]).ToArray();
        }
        public static IEnumerable<int[]> CombinationsRosettaWoRecursion(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>(m);
            stack.Push(0);
            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();
                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index != m) continue;
                    yield return (int[])result.Clone();
                    break;
                }
            }
        }
        public static IEnumerable<T[]> CombinationsRosettaWoRecursion<T>(T[] array, int m)
        {
            if (array.Length < m)
                throw new ArgumentException("Array length can't be less than number of selected elements");
            if (m < 1)
                throw new ArgumentException("Number of selected elements can't be less than 1");
            T[] result = new T[m];
            foreach (int[] j in CombinationsRosettaWoRecursion(m, array.Length))
            {
                for (int i = 0; i < m; i++)
                {
                    result[i] = array[j[i]];
                }
                yield return result;
            }
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
