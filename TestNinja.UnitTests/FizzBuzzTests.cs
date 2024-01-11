using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutput_NumberDivisibleByThreeAndFive_ReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }
        
        [Test]
        public void GetOutput_NumberDivisibleByThree_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(3);
            Assert.That(result, Is.EqualTo("Fizz"));
        }
        [Test]
        public void GetOutput_NumberDivisibleByFive_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(5);
            Assert.That(result, Is.EqualTo("Buzz"));
        }
        [Test]
        public void GetOutput_NumberNonDivisibleByThreeOrFive_ReturnSameNumber()
        {
            var result = FizzBuzz.GetOutput(1);
            Assert.That(result, Is.EqualTo("1"));
        }
    }
}