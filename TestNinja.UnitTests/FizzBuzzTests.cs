using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    public class FizzBuzzTests
    {
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(1, "1")]
        public void GetOuptPut_VaidateCorrectString_ReturnsCorrectString(int number, string expectedResult)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
