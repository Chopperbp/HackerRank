namespace HacerRank.Compete.NumberOfIntegers
{
    public class NumberOfIntegers
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
            var a = getNumberOfInteger(R, K);
            var b = getNumberOfInteger(L, K);
            return mod(a - b, 1000000007);
        }
        public static int getNumberOfInteger(string L, int K)
        {
            //var s = L.TrimStart('0');
            var s = L;
            var n = s.Length;
            int[,,] dp = new int[n + 1, 2, K + 2];

            // Initialise 
            for (int i = 0; i <= n; i++)
                for (int j = 0; j < 2; j++)
                    for (int x = 0; x <= K; x++)
                        dp[i, j, x] = 0;

            // Base 
            dp[0, 0, 0] = 1;

            // Calculate all states 
            // For every state, from numbers 1 to N, 
            // the count of numbers which contain exactly j 
            // non zero digits is being computed and updated 
            // in the dp array. 
            for (int i = 0; i < n; ++i)
            {
                int sm = 0;
                while (sm < 2)
                {
                    for (int j = 0; j < K + 1; ++j)
                    {
                        int x = 0;
                        while (x <= (sm != 0 ? 9 : s[i] - '0'))
                        {
                            checked
                            {
                                var b = dp[i, sm, j];
                                var a = dp[i + 1, (sm != 0 || x < (s[i] - '0')) ? 1 : 0, j + (x > 0 ? 1 : 0)];
                                dp[i + 1, (sm > 0 || x < (s[i] - '0')) ? 1 : 0, j + (x > 0 ? 1 : 0)] = mod(a + b, 1000000007);
                            }
                            ++x;
                        }
                    }
                    ++sm;
                }
            }

            // Return the required answer 
            return dp[n, 0, K] + dp[n, 1, K];
        }
        private static int mod(int x, int m)
        {
            int r = x % m;
            return r < 0 ? r + m : r;
        }
    }
}
