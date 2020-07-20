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
    }
}
