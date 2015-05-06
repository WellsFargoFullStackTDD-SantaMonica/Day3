using System;
using Xunit;

namespace AdventureWorksDAL.xUnitTests
{
    public class xUnitTests
    {

        [Fact]
        // Traits
        //[Trait("Category", "Empty")]
        //[Trait("Owner", "Jeff")]
        //[Trait("Priority", "2")]
        //[Trait("Duration", "Long")]
        public void xUnitEmptyTestMethod()
        { 
        }


        [Fact]
        public void ProductCalculateSalesTax_PositiveValue_CalculatedCorrectly()
        {
            // Arrange
            var price = 49.99M;
            var expectedSalesTax = price * .10M;
            var product = new Product { ListPrice = price };

            // Act
            var result = product.CalculateSalesTax();

            // Assert
            Assert.Equal(expectedSalesTax, result);                    // Equal
            //Assert.True(expectedSalesTax == result);                   // Comparison
            //Assert.NotEqual(expectedSalesTax, result);                 // Not Equal
            //Assert.Same(expectedSalesTax, result);                     // Same Object
            //Assert.NotSame(expectedSalesTax, result);                  // Different Objects
            //Assert.NotNull(product);                                   // Null Check  
        }


        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        //[InlineData(-1)]
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
            Assert.Equal(expectedSalesTax, result);
        }


        [Fact]
        public void ProductCalculateSalesTax_GivenANegativeValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var price = -1M;
            var expectedSalesTax = price * .10M;
            var product = new Product { ListPrice = price };

            // Act
            //var result = product.CalculateSalesTax();
            Action testMethod = () => product.CalculateSalesTax();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(testMethod);
        }
    }
}
