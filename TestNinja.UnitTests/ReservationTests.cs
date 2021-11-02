using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_RetursTrue()
        {
            var reservation = new Reservation();

            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnsTrue()
        {
            var user = new User();
            var reservation = new Reservation() { MadeBy = user};

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnsFalse()
        {
            var reservation = new Reservation() { MadeBy = new User() };

            var result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);
        }
    }
}
