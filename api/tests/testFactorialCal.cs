using NUnit.Framework;
using api.Services;
using System;

namespace api.tests
{

    public class testFactorialCal
    {
        private FactorialCalculator factorialCalculator;
        private const int testDate = 11;

        [SetUp]
        public void Setup()
        {
            factorialCalculator = new FactorialCalculator();
        }

        [Test]
        [TestCase(1,1)]
        [TestCase(2,2)]
        [TestCase(3,6)]
        [TestCase(10, 3628800)]
        public void Test_less_than_10(int input, int output)
        {
            int result = factorialCalculator.Calculate(input);

            Assert.AreEqual(output, result);
        }

        [Test]
        public void Test_equal_greater_than_10()
        {
            var err = Assert.Throws<NotSupportedException>( () => factorialCalculator.Calculate(testDate));
            Assert.That( err.Message, Is.EqualTo($"n > {testDate-1} is not supported") );
        }

    }
}