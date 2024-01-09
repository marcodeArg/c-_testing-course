using System.Linq;
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
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [Ignore("Because I created a parameterized test")]
        public void Max_SecondArgumentIsGreater_ReturnSecondArgument()
        {
            var result = _math.Max(1, 2);
            
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        [Ignore("Because I created a parameterized test")]
        public void Max_BothArgumentsAreEquals_ReturnsSecondArgument()
        {
            var result = _math.Max(2, 2);
            
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void GetOddNumbers_LimitIsGraterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);
            
            // Types of assertions in collections
            
            //Assert.That(result, Is.Not.Empty);
            //Assert.That(result.Count(), Is.EqualTo(3));
            
            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(2));
            //Assert.That(result, Does.Contain(3));
            
            Assert.That(result, Is.EquivalentTo(new [] {1, 3, 5}));
            
            // Assert.That(result, Is.Ordered); // Check if the array is ordered
            // Assert.That(result, Is.Unique); // Check if the array contains non duplicated elements 
        }
        
    }
}