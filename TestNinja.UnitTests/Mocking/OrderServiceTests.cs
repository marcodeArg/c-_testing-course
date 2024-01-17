using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var mockStorage = new Mock<IStorage>();
            var service = new OrderService(mockStorage.Object);

            var order = new Order();
            service.PlaceOrder(order);
            
            mockStorage.Verify(storage => storage.Store(order));
        }
    }
}