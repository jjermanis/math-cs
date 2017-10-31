using System;
using System.Collections.Generic;

namespace math_cs
{ 
    /// <summary>
    /// Note: If and when C# supports class extension with static methods, that ought to be used
    /// for these methods
    /// </summary>
    public static partial class MathExt
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

        public static IReadOnlyDictionary<int, int> GetPrimeFactors(int n)
        {
            if (n < 2)
                throw new ArgumentOutOfRangeException(
                    $"Should only be called with integers 2 or greater; called with {n}");

            var remaining = n;

            var result = new Dictionary<int, int>();
            while (remaining > 1)
            {
                var factor = (int)SmallestPrimeFactor(remaining);
                if (result.ContainsKey(factor))
                    result[factor]++;
                else
                    result[factor] = 1;
                remaining /= factor;
            }
            return result;
        }

        private static long SmallestPrimeFactor(long n)
        {
            // TODO: refactor the common logic here and in IsPrime()
            if (n < 2)
                throw new ArgumentOutOfRangeException(
                    $"Should only be called with integers 2 or greater; called with {n}");
            if (n % 2 == 0)
                return 2;
            if (n % 3 == 0)
                return 3;
            long factor = 5;
            while (factor * factor <= n)
            {
                if (n % factor == 0)
                    return factor;
                if (n % (factor + 2) == 0)
                    return factor + 2;
                factor += 6;
            }
            // n must be prime
            return n;
        }

    }

}
