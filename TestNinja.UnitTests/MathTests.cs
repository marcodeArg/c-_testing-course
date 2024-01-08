using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }
        
        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            // Arrange
            // hecho con el setup

            // Act
            var result = _math.Add(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnFirstArgument()
        {
            var result = _math.Max(2, 1);
            
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnSecondArgument()
        {
            var result = _math.Max(1, 2);
            
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_BothArgumentsAreEquals_ReturnsSecondArgument()
        {
            var result = _math.Max(2, 2);
            
            Assert.That(result, Is.EqualTo(2));
        }
        
    }
}