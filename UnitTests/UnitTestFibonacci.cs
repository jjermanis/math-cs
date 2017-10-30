using math_cs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTestFibonacci
    {
        [TestMethod]
        public void FiboBaseCase()
        {
            var answerKey = new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };
            var first10 = MathExt.FibonacciNumbers().Take(10);
            Assert.IsTrue(answerKey.SequenceEqual(first10));
        }

        [TestMethod]
        public void FiboBigCase()
        {
            var num = MathExt.FibonacciNumbers().Skip(45).First();
            Assert.AreEqual(num, 1_836_311_903);
        }
    }
}
