using math_cs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTestPrimeFactors
    {
        private static IReadOnlyDictionary<int, int> Test(int n)
            => MathExt.GetPrimeFactors(n);

        [TestMethod]
        public void PrimeFactorBaseCases()
        {
            var result = Test(6);
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[2] == 1);
            Assert.IsTrue(result[3] == 1);

            result = Test(60);
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[2] == 2);
            Assert.IsTrue(result[3] == 1);
            Assert.IsTrue(result[5] == 1);

            result = Test(13);
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[13] == 1);

            result = Test(9_699_690);
            Assert.IsTrue(result.Count == 8);
            Assert.IsTrue(result[2] == 1);
            Assert.IsTrue(result[3] == 1);
            Assert.IsTrue(result[5] == 1);
            Assert.IsTrue(result[7] == 1);
            Assert.IsTrue(result[11] == 1);
            Assert.IsTrue(result[13] == 1);
            Assert.IsTrue(result[17] == 1);
            Assert.IsTrue(result[19] == 1);
        }

        [TestMethod]
        public void PrimeFactorBoundaryCases()
        {
            // Max int is prime
            var result = Test(Int32.MaxValue);
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[Int32.MaxValue] == 1);

            // Max int minus 1 is largest int with multiple factors
            result = Test(Int32.MaxValue-1);
            Assert.IsTrue(result.Count == 7);
            Assert.IsTrue(result[2] == 1);
            Assert.IsTrue(result[3] == 2);
            Assert.IsTrue(result[7] == 1);
            Assert.IsTrue(result[11] == 1);
            Assert.IsTrue(result[31] == 1);
            Assert.IsTrue(result[151] == 1);
            Assert.IsTrue(result[331] == 1);

            // Int with largest factor (other than itself)
            result = Test(2147117569);
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[46337] == 2);
        }

        [TestMethod]
        public void PrimeFactorErrorCases()
        {
            // All of these should throw
            PrimeFactorException(1);
            PrimeFactorException(0);
            PrimeFactorException(-1);
            PrimeFactorException(Int32.MinValue);
        }

        private void PrimeFactorException(int n)
        {
            try
            {
                Test(n);
                Assert.Fail($"Exception expected for {n}");
            }
            catch(ArgumentOutOfRangeException)
            {
            }
        }
    }
}
