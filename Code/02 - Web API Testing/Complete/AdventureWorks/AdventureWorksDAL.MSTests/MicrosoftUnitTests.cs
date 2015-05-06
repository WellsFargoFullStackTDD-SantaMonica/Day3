using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorksDAL;

namespace AdventureWorksDAL.MSTests
{
    [TestClass]
    public class MicrosoftUnitTests
    {
        [TestMethod]
        // Traits
        /*[TestCategory("Empty")]
        [Owner("Jeff")]
        [Priority(2)]
        [TestProperty("Duration", "Long")]*/
        public void MicrosoftEmptyUnitTestMethod()
        {
        }


        // Note: If Test Class Name was ProductTests then
        //          Test Method Name would be
        //          CalculateSalesTax_PositiveValue_CalculatedCorrectly()
        [TestMethod]
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


        // Paramterized Tests
        [TestMethod]
        public void ProductCalculateSalesTax_PriceIs1_CalculatedCorrectly()
        {
            ProductCalculateSalesTax_GivenAValue_CalculatedCorrectly(1M);
        }
        [TestMethod]
        public void ProductCalculateSalesTax_PriceIs0_CalculatedCorrectly()
        {
            ProductCalculateSalesTax_GivenAValue_CalculatedCorrectly(0M);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ProductCalculateSalesTax_PriceIsNegative1_CalculatedCorrectly()
        {
            ProductCalculateSalesTax_GivenAValue_CalculatedCorrectly(-1M);
        }

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

        [TestInitialize]
        public void TestInitialize()
        {
            System.Diagnostics.Debug.WriteLine("TestInitalize");
        }
        [TestCleanup]
        public void TestCleanup()
        {
            System.Diagnostics.Debug.WriteLine("TestCleanup");
        }

        public Product ProductFactory(decimal Price)
        {
            return new Product { ListPrice = Price };
        }
    }
}
