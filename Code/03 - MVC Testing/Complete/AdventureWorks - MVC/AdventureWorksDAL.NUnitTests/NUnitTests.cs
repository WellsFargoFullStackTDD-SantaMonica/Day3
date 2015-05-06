using System;
using NUnit.Framework;
using AdventureWorksDAL;

namespace AdventureWorksDAL.NUnitTests
{
    [TestFixture]
    public class NUnitTests
    {
        [Test]
        // Traits
        /*[Category("Empty")]
        [Property("Owner", "Jeff")]
        [Property("Priority",2)]
        [Property("Duration", "Long")]*/
        public void NUnitEmptyTestMethod() 
        {

        }


        [Test]
        public void ProductCalculateSalesTax_PositiveValue_CalculatedCorrectly()
        {
            // Arrange
            var price = 49.99M;
            var expectedSalesTax = price * .10M;
            var product = new Product { ListPrice = price };

            // Act
            var result = product.CalculateSalesTax();

            // Assert
            Assert.AreEqual(expectedSalesTax, result);                    // Equal
            //Assert.IsTrue(expectedSalesTax == result);                    // Comparison
            //Assert.AreEqual(expectedSalesTax, result, "Message");         // Equal
            //Assert.AreNotEqual(expectedSalesTax, result);                 // Not Equal
            //Assert.AreSame(expectedSalesTax, result);                     // Same Object
            //Assert.AreNotSame(expectedSalesTax, result);                  // Different Objects
            //Assert.Fail("Fail {0} vs {1}", expectedSalesTax, result);     // Auto Fail
            //Assert.Inconclusive("Inconclusive");                          // Inconclusive
            //Assert.IsNotNull(product);                                    // Null Check  
        }


        [TestCase(1)]
        [TestCase(0)]
        public void ProductCalculateSalesTax_GivenAValue_CalculatedCorrectly(decimal price)
        {
            // Arrange
            var expectedSalesTax = price * .10M;
            var product = new Product { ListPrice = price };

            // Use Factory Method
            //var product = ProductFactory(price);

            // Act
            var result = product.CalculateSalesTax();

            // Assert
            Assert.AreEqual(expectedSalesTax, result);
        }


        [SetUp]
        public void TestInitialize()
        {
            System.Diagnostics.Debug.WriteLine("TestInitalize");
        }
        [TearDown]
        public void TestCleanup()
        {
            System.Diagnostics.Debug.WriteLine("TestCleanup");
        }


        [TestCase(-1)]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ProductCalculateSalesTax_GivenANegativeValue_ThrowsArgumentOutOfRangeException(decimal price)
        {
            // Arrange
            var expectedSalesTax = price * .10M;
            var product = new Product { ListPrice = price };

            // Act
            //var result = product.CalculateSalesTax();
            TestDelegate testMethod = () => product.CalculateSalesTax();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(testMethod);
        }
    }
}
