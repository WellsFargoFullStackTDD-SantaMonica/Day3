using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using AdventureWorksDAL;
using System.Collections.Generic;

namespace AdventureWorksDAL.MSTests
{
    [TestClass]
    public class MicrosoftIsolationFramework
    {
        [TestMethod]
        public void ProductToTimeZoneTime_SentTimeZone_ReturnsCorrectTime()
        {
            // Test that ToTimeZoneTime Really Works (Not Part of Real Test)
            var product = new Product();
            var test = product.ToTimeZoneTime(DateTime.UtcNow);
            System.Diagnostics.Debug.WriteLine("product.ToTimeZoneTime returns " + test);

            // Arrange
            var currentUtcDateTime = DateTime.UtcNow;
            var expectedDateTime = "01/01/2015 12:00:00 AM";
            var productSub = Substitute.For<Product>();
            System.Diagnostics.Debug.WriteLine("productSub.ToTimeZoneTime returns " + 
                productSub.ToTimeZoneTime(currentUtcDateTime));

            productSub.ToTimeZoneTime(DateTime.UtcNow).ReturnsForAnyArgs(expectedDateTime);
            //productSub.ToTimeZoneTime(Arg.Any<DateTime>()).Returns(expectedDateTime);

            // Act
            var results = productSub.ToTimeZoneTime(currentUtcDateTime);

            // Assert
            Assert.AreEqual(expectedDateTime, results);
            //productSub.Received().ToTimeZoneTime(currentUtcDateTime);
            //productSub.DidNotReceive().ToTimeZoneTime(DateTime.UtcNow);
        }

        
    }
}
