using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    class DemeritPointsCalculatorTests
    {
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsNegative_ReturnsArgumentOutOfRangeException(int speed)
        {
            var demerit = new DemeritPointsCalculator();

            Assert.Throws<ArgumentOutOfRangeException>(() => demerit.CalculateDemeritPoints(speed));
        }

        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
        {
            var demerit = new DemeritPointsCalculator();

            var result = demerit.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}
