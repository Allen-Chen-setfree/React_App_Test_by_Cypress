using NUnit.Framework;
using api.Services;
using System;

namespace api.tests
{

    public class testRandomSqaureCal
    {
        private RandomSquareCalculator randomSquareCalculator;
        private const int testDate = 0;

        [SetUp]
        public void Setup()
        {
            randomSquareCalculator = new RandomSquareCalculator();

        }

        [Test]

        #region
        [TestCase(1, new int[1] { 0 })]
        [TestCase(2, new int[2] { 0, 1 })]
        [TestCase(3, new int[3] { 0, 1, 4 })]
        public void Test_greater_than_0(int input, ref int[] output)
        {
            double result = randomSquareCalculator.Calculate(input);

            CollectionAssert.Contains(output, result);
        }
        #endregion

        
        [Test]
        public void Test_equal_less_than_0()
        {
            var err = Assert.Throws<Exception>(() => randomSquareCalculator.Calculate(testDate));
            Assert.That( err.Message, Is.EqualTo("max must be > 0") );
        }
  
    }
}