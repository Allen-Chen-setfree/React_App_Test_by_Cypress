using NUnit.Framework;
using api.Services;
using System;

namespace api.tests
{

    public class testFibonacciCal
    {
        private FibonacciCalculator fibonacciCalculator;
        private const int testDate = 11;

        [SetUp]
        public void Setup()
        {
            fibonacciCalculator = new FibonacciCalculator();
        }

        [Test]
        #region
        [TestCase(0,0)]
        [TestCase(1,1)]
        [TestCase(2,1)]
        [TestCase(10,55)]
        public void Test_less_than_10(int input, int output)
        {
            int result = fibonacciCalculator.Calculate(input);

            Assert.AreEqual(output, result);
        }
        #endregion

        
        [Test]
        [TestCase(testDate)]
        [TestCase(-1)]
        public void Test_equal_greater_than_10_or_less_than_0(int input)
        {
            var err = Assert.Throws<NotSupportedException>(() => fibonacciCalculator.Calculate(input));
            Assert.That( err.Message, Is.EqualTo($"n > {testDate-1} or n < 0 is not supported") );
        }
  
    }
}