﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace AdventureWorksDAL.MSTests
{
    [TestClass]
    public class IsolationFramework
    {
        [TestMethod]
        public void ProductToTimeZoneTime_SentTimeZone_ReturnsCorrectTime()
        {
            // Side Test of Functionality
            var product = new Product();
            String test = product.ToTimeZoneTime(DateTime.UtcNow);
            System.Diagnostics.Debug.WriteLine(
                "product.ToTimeZoneTime returns " + test);

            // Arrange
            var currentUtcDateTime = DateTime.UtcNow;
            var expectedDateTime = "01/01/2015 12:00:00 AM";
            var productSub = Substitute.For<Product>();


            //productSub.ToTimeZoneTime(currentUtcDateTime).Returns("Hi");
            productSub.ToTimeZoneTime(Arg.Any<DateTime>()).Returns("Hi Again");


            System.Diagnostics.Debug.WriteLine(
                "productSub.ToTimeZoneTime returns " +
                productSub.ToTimeZoneTime(currentUtcDateTime));

            // Act
            var results = product.ToTimeZoneTime(currentUtcDateTime);

            // Assert
            Assert.AreEqual(expectedDateTime, results);

        }
    }
}
