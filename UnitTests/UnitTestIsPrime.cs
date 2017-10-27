using System;
using math_cs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestIsPrime
    {
        private static bool IsPrime(int n)
            => MathExt.IsPrime(n);

        void Test(bool expected, int n)
            => Assert.AreEqual(expected, IsPrime(n), $"{n} failed, expected {expected}");

        long TicksToMicroseconds(long ticks)
            => ticks * 1000 / TimeSpan.TicksPerMillisecond;

        [TestMethod]
        public void TestNonPositiveNumbers()
        {
            void Test(int n)
                => Assert.IsFalse(IsPrime(n), $"{n} IsPrime; only positive numbers are prime");

            Test(0);
            Test(-1);
            Test(-2);
            Test(-4);
            Test(-5);
            Test(-6);
            Test(-255);
            Test(-256);
            Test(-65535);
            Test(-65536);
            Test(Int32.MinValue);
        }

        [TestMethod]
        public void TestBaseCases()
        {
            Test(true, 2);
            Test(true, 3);
            Test(true, 5);
            Test(true, 7);
            Test(false, 1);
            Test(false, 4);
            Test(false, 6);
            Test(false, 9);
        }

        [TestMethod]
        public void TestBoundaryCases()
        {
            Test(false, 255);
            Test(false, 256);
            Test(true, 257);
            Test(false, 65535);
            Test(false, 65536);
            Test(true, 65537);
            Test(true, Int32.MaxValue);
            Test(false, Int32.MaxValue-1);
            Test(true, 2147483629); // 2nd biggest Int32 prime
            Test(false, 2147117569); // Int32 with biggest prime factor
        }

        [TestMethod]
        public void TestRanges()
        {
            void TestRange(int start, int end, int expectedCount)
            {
                var count = 0;
                for (var x = start; x <= end; x++)
                    if (IsPrime(x))
                        count++;
                Assert.AreEqual(expectedCount, count, 
                    $"Expected {expectedCount} primes between {start} and {end}; got {count}");
            }

            TestRange(0, 100, 25);
            TestRange(0, 1_000, 168);
            TestRange(0, 10_000, 1_229);
            TestRange(0, 100_000, 9_592);
            TestRange(0, 1_000_000, 78_498);
            TestRange(0, 10_000_000, 664_579);
        }

        [TestMethod]
        public void TestPerformance()
        {
            void TestSpeed(int n, bool expected)
            {
                const long ITERATIONS = 10000;
                // Average performance threshold - 100 microseconds per test
                const long TIME_LIMIT = ITERATIONS * 100;
                var start = DateTime.Now.Ticks;
                for (var x=0;x< ITERATIONS; x++)
                    Test(expected, n);
                var ticks = DateTime.Now.Ticks - start;
                Assert.IsTrue(TicksToMicroseconds(ticks) < TIME_LIMIT, 
                    $"{n} is too slow (averaged {TicksToMicroseconds(ticks)/ITERATIONS} \u00B5s)");
            }

            TestSpeed(2, true);
            TestSpeed(65537, true);
            TestSpeed(65537, true);
            TestSpeed(Int32.MaxValue, true);
            TestSpeed(2147117569, false);
            TestSpeed(2147483629, true);
        }
    }
}
