using System;
using NUnit.Framework;

namespace FizzBizz.Tests
{
    [TestFixture]
    public class FizzBuzzUnitTests
    {
        
        [TestCase(6, "Fizz")]
        [TestCase(10, "Buzz")]
        [TestCase(30, "FizzBuzz")]
        [TestCase(26, "26")]
        public void GivenListValidNumbers_WhenCalculateNumbers_ThanShouldHaveValidString(int number, string expected)
        {
            var fizzBuzz = new FizzBuzz.FizzBuzz();

            var result = fizzBuzz.GetFizzBizzResult(number);

            Assert.AreEqual(expected, result);
        }

       
        [TestCase(0)]
        [TestCase(122)]
        public void GivenListNoValidNumbers_WhenCalculateNumbers_ThrowsArgumentOutOfRangeException(int number)
        {
            var fizzBuzz = new FizzBuzz.FizzBuzz();
            Func<int, string> func = fizzBuzz.GetFizzBizzResult;

            Assert.That(() =>
                func(number), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}