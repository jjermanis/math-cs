namespace math_cs
{ 
    /// <summary>
    /// Note: If and when C# supports class extension with static methods, that ought to be used
    /// for these methods
    /// </summary>
    public static class MathExt
    {
        public static bool IsPrime(int n)
        {
            // 2 is the smallest prime
            if (n < 2)
                return false;

            // true iff n is 2 or 3
            if (n < 4)
                return true;

            // Special handling to check if number is divisible by 2 or 3
            if (n % 2 == 0 || n % 3 == 0)
                return false;

            // Since we have already checked for 2 and 3, we can skip even
            // numbers, and those evenly divisible by 3.
            var factor = 5;
            while (factor * factor <= n &&
                   factor <= 46341)
            {
                if (n % factor == 0 ||
                    n % (factor + 2) == 0)
                    return false;
                factor += 6;
            }
            return true;
        }
    }
}
