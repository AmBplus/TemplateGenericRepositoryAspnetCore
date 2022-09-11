using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Ninja.Models;
// Test MsUnitTest
namespace Ninja.UnitTest
{
    [TestClass]
    public class ReservertionTest
    {
        //[TestMethod]
        //public void CanBeCancelledBy_Scenario_ExpectedBehavior()
        //{
        //    // Arrange
        //    Reservation reservation = new Reservation();
        //    // Act
        //    var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });
        //    // Assert 
        //    Assert.IsTrue(result);
        //}
        [TestMethod]
        public void CanBeCancelledBy_IsAdmin_ReturnTrue()
        {
            // Arrange
            Reservation reservation = new Reservation();
            // Act
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });
            // Assert 
            Assert.IsTrue(result);
        }
        [TestMethod] 
        public void CanBeCancelledBy_IsAdmin_ReturnFalse()
        {
            // Arrange
            Reservation reservation = new Reservation();
            // Act
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = false });
            // Assert 
            Assert.IsFalse(result);
        }
        
        
    }
}
