using Ninja.Models;
using NUnit.Framework;

namespace Ninja.UnitTest
{
    [TestFixture]
    public class ReservationNunitTest
    {
        [Test]
        public void CanCancelledBy_AdminCanceling_ReturnTrue()
        {
            // Arrange 
            Reservation reservation = new Reservation();
            // Act
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });
            // Assert 
            Assert.That(result,Is.True);
        }

        [Test]
        public void CanCancelledBy_SameUserOrdered_ReturnTrue()
        {
            // Arrange
            User user = new User();
            Reservation reservation = new Reservation(){ MadyBy = user};
            // Act 
            var result = reservation.CanBeCancelledBy(user);
            // Assert 
            Assert.That(result == true);
        }
        [Test]
        public void CanBeCancelledBy_AnotherUserNotOwnerOfOrder_ReturnFalse()
        {
            // Arrange 
            Reservation reservation = new Reservation(){ MadyBy = new User()};
            // Act 
            var result = reservation.CanBeCancelledBy(new User());
            // Assert 
            Assert.That(result,Is.False);
        }
    }
}