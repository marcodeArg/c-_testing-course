using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnTrue()
        {
            //Arranges
            var reservation = new Reservation();

            //Art
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true } );

            //Assert
            Assert.That ( result );
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnTrue() 
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation{ MadeBy = user};

            //Art
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.That(result);
    
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnFalse()
        {
            // Arrange
            var reservation = new Reservation { MadeBy = new User()};

            //Art
            var result = reservation.CanBeCancelledBy(new User());

            //Assert
            Assert.That(result, Is.False); // or it can be written as (result == false)
        }

    }


}
