using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorksDAL;
using AdventureWorksMVC.Controllers;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using System.Data.Entity;
using System.Web.Mvc;

namespace AdventureWorksMVC.Tests
{
    [TestClass]
    public class ProductsControllerTests
    {
        [TestMethod]
        public void ProductsController_SentProducts_ReturnsCorrectCount()
        {
            // Arrange
            var rowsToCreate = 5;
            var controller = new ProductsController(ContextSubFactory(rowsToCreate));

            // Act
            var viewResult = (ViewResult)controller.Index();
            var rowsInModel = ((List<Product>)viewResult.Model).Count;

            // Assert
            Assert.AreEqual(rowsToCreate, rowsInModel);
        }

        [TestMethod]
        public void ProductsController_CreateProduct_ProductAdded()
        {
            // Arrange
            var contextSub = ContextSubFactory(0);
            var controller = new ProductsController(contextSub);
            var Product = new Product();
            
            // Act
            controller.Create(Product);
            
            // Assert
            contextSub.Products.Received().Add(Product);
        }

        private IAdventureWorksContext ContextSubFactory(int RowsOfData)
        {
            var data = new List<Product>();
            for (int x = 0; x < RowsOfData; x++)
            {
                data.Add(new Product { ProductID = x, Name = "Demo" + x, ListPrice = x * 10 });
            }
            var queryableData = data.AsQueryable();

            var productsSub = Substitute.For<DbSet<Product>, IQueryable<Product>>();
            ((IQueryable<Product>)productsSub).Provider.Returns(queryableData.Provider);
            ((IQueryable<Product>)productsSub).Expression.Returns(queryableData.Expression);
            ((IQueryable<Product>)productsSub).ElementType.Returns(queryableData.ElementType);
            ((IQueryable<Product>)productsSub).GetEnumerator().Returns(queryableData.GetEnumerator());

            var contextSub = Substitute.For<IAdventureWorksContext>();
            contextSub.Products = productsSub;

            return contextSub;
        }
    }
}
