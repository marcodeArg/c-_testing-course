using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeRepository> _mockEmployeeRepo;
        private EmployeeController _employeeController;
        
        [SetUp]
        public void SetUp()
        {
            _mockEmployeeRepo = new Mock<IEmployeeRepository>();
            _employeeController = new EmployeeController(_mockEmployeeRepo.Object);
        }
        
        [Test]
        public void DeleteEmployee_WhenCalled_RemoveTheEmployee()
        {
            _employeeController.DeleteEmployee(1);
            _mockEmployeeRepo.Verify(er => er.Delete(1));
        }

        [Test]
        public void DeleteEmployee_WhenCalled_ReturnActionResult()
        {
            var result = _employeeController.DeleteEmployee(1);
            
            Assert.That(result, Is.InstanceOf<ActionResult>());
        }
    }
}