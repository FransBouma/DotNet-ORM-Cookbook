﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Recipes.ModelWithChildren
{
    /// <summary>
    /// This scenario performs basic CRUD operations on a model that contains a collection of child objects.
    [TestCategory("ModelWithChildren")]
    public abstract class ModelWithChildrenTests<TProductLine, TProduct> : TestBase
       where TProductLine : class, IProductLine<TProduct>, new()
       where TProduct : class, IProduct, new()
    {
        const string Alpha = "ABCDEFG";

        [TestMethod]
        public void CreateAndAddChild()
        {
            var repository = GetScenario();

            TProductLine line = CreateProductLine();

            var newKey = repository.Create(line);
            Assert.IsTrue(newKey >= 1000, "ProductLineKey under 1000 was not generated by the database");

            //Read with children
            var echo = repository.GetByKey(newKey, true);
            CompareLineAndProducts(newKey, line, echo!);

            //Update Children
            echo!.Products.Add(new TProduct()
            {
                ProductName = "Part " + Alpha[5],
                ProductWeight = 123 + (5 * .45M),
                ShippingWeight = 125 + (5 * .45M)
            });
            repository.Update(echo);

            //Check against updated values
            var updated = repository.GetByKey(newKey, true);
            CompareLineAndProducts(newKey, echo, updated!);
        }

        /// <summary>
        /// Create and delete an object graph.
        /// </summary>
        [TestMethod]
        public void CreateAndDelete()
        {
            var repository = GetScenario();

            TProductLine line = CreateProductLine();

            var newKey = repository.Create(line);
            Assert.IsTrue(newKey >= 1000, "ProductLineKey under 1000 was not generated by the database");

            //Read with children
            var echo = repository.GetByKey(newKey, true);
            CompareLineAndProducts(newKey, line, echo!);

            repository.Delete(echo!);

            var check = repository.GetByKey(newKey, true);
            Assert.IsNull(check, "Record should have been deleted");
        }

        /// <summary>
        /// Create and delete an object graph.
        /// </summary>
        [TestMethod]
        public void CreateAndDeleteByKey()
        {
            var repository = GetScenario();

            TProductLine line = CreateProductLine();

            var newKey = repository.Create(line);
            Assert.IsTrue(newKey >= 1000, "ProductLineKey under 1000 was not generated by the database");

            //Read with children
            var echo = repository.GetByKey(newKey, true);
            CompareLineAndProducts(newKey, line, echo!);

            repository.DeleteByKey(newKey);

            var check = repository.GetByKey(newKey, true);
            Assert.IsNull(check, "Record should have been deleted");
        }

        [TestMethod]
        public void CreateAndDeleteChild()
        {
            var repository = GetScenario();

            TProductLine line = CreateProductLine();

            var newKey = repository.Create(line);
            Assert.IsTrue(newKey >= 1000, "ProductLineKey under 1000 was not generated by the database");

            //Read with children
            var echo = repository.GetByKey(newKey, true);
            CompareLineAndProducts(newKey, line, echo!);

            //Update Children
            echo!.Products.Remove(echo!.Products.First());
            repository.Update(echo);

            //Check against updated values
            var updated = repository.GetByKey(newKey, true);
            CompareLineAndProducts(newKey, echo, updated!);
        }

        /// <summary>
        /// Create and read back an object graph.
        /// </summary>
        [TestMethod]
        public void CreateAndFindByName()
        {
            var repository = GetScenario();

            TProductLine line = CreateProductLine();

            var newKey = repository.Create(line);
            Assert.IsTrue(newKey >= 1000, "ProductLineKey under 1000 was not generated by the database");

            {
                var echo = repository.FindByName(line.ProductLineName!, false).FirstOrDefault();
                //Simple read
                Assert.IsNotNull(echo);
                Assert.AreEqual(newKey, echo!.ProductLineKey);
                Assert.AreEqual(line.ProductLineName, echo.ProductLineName);
                Assert.IsTrue(echo.Products == null || echo.Products.Count == 0, "Child records were not requested");
            }

            {
                //Read with children
                var echo = repository.FindByName(line.ProductLineName!, true).FirstOrDefault();
                CompareLineAndProducts(newKey, line, echo);
            }
        }

        /// <summary>
        /// Create and read back an object graph.
        /// </summary>
        [TestMethod]
        public void CreateAndReadBack_NoChildren()
        {
            var repository = GetScenario();

            TProductLine line = CreateProductLine();

            var newKey = repository.Create(line);
            Assert.IsTrue(newKey >= 1000, "ProductLineKey under 1000 was not generated by the database");

            //Simple read
            var echo = repository.GetByKey(newKey, false);
            Assert.IsNotNull(echo);
            Assert.AreEqual(newKey, echo!.ProductLineKey);
            Assert.AreEqual(line.ProductLineName, echo.ProductLineName);
            Assert.IsTrue(echo.Products == null || echo.Products.Count == 0, "Child records were not requested");
        }

        /// <summary>
        /// Create and read back an object graph.
        /// </summary>
        [TestMethod]
        public void CreateAndReadBack_WithChildren()
        {
            var repository = GetScenario();

            TProductLine line = CreateProductLine();

            var newKey = repository.Create(line);
            Assert.IsTrue(newKey >= 1000, "ProductLineKey under 1000 was not generated by the database");

            //Read with children
            var echo = repository.GetByKey(newKey, true);
            CompareLineAndProducts(newKey, line, echo);
        }

        [TestMethod]
        public void CreateAndUpdateChild()
        {
            var repository = GetScenario();

            TProductLine line = CreateProductLine();

            var newKey = repository.Create(line);
            Assert.IsTrue(newKey >= 1000, "ProductLineKey under 1000 was not generated by the database");

            //Read with children
            var echo = repository.GetByKey(newKey, true);
            CompareLineAndProducts(newKey, line, echo);

            //Update Children
            echo!.Products.First().ProductWeight += 5;
            echo.Products.First().ShippingWeight += 6;
            echo.Products.Skip(1).First().ProductName = "Updated " + DateTime.Now.Ticks;
            repository.Update(echo);

            //Check against updated values
            var updated = repository.GetByKey(newKey, true);
            CompareLineAndProducts(newKey, echo, updated);
        }

        /// <summary>
        /// Create and update a row.
        /// </summary>
        [TestMethod]
        public void CreateAndUpdateChildSeparately()
        {
            var repository = GetScenario();

            TProductLine line = CreateProductLine();

            var newKey = repository.Create(line);
            Assert.IsTrue(newKey >= 1000, "ProductLineKey under 1000 was not generated by the database");

            //Read with children
            var echo = repository.GetByKey(newKey, true);
            CompareLineAndProducts(newKey, line, echo);

            //Update Children
            var product = echo!.Products.First();
            product.ProductWeight += 5;
            product.ShippingWeight += 6;
            product.ProductName = "Updated " + DateTime.Now.Ticks;
            repository.Update(product);

            //Check against updated values
            var updated = repository.GetByKey(newKey, true);
            CompareLineAndProducts(newKey, echo, updated);
        }

        /// <summary>
        /// Create and update an object graph.
        /// </summary>
        [TestMethod]
        public void CreateAndUpdateParent()
        {
            var repository = GetScenario();

            TProductLine line = CreateProductLine();

            var newKey = repository.Create(line);
            Assert.IsTrue(newKey >= 1000, "ProductLineKey under 1000 was not generated by the database");

            //Read with children
            var echo = repository.GetByKey(newKey, true);
            CompareLineAndProducts(newKey, line, echo);

            //Update Parent
            echo!.ProductLineName = "Updated " + DateTime.Now.Ticks;
            repository.Update(echo);

            //Check against updated values
            var updated = repository.GetByKey(newKey, true);
            CompareLineAndProducts(newKey, echo, updated);
        }

        [TestMethod]
        public void GetAll_NoChildren()
        {
            var repository = GetScenario();
            var results = repository.GetAll(false);
            foreach (var line in results)
                Assert.IsTrue(line.Products == null || line.Products.Count == 0, "Child records were not requested");
        }

        [TestMethod]
        public void GetAll_WithChildren()
        {
            var repository = GetScenario();
            var results = repository.GetAll(true);
            var hasChildRows = false;
            foreach (var line in results)
                hasChildRows = hasChildRows || line.Products?.Count > 0;

            Assert.IsTrue(hasChildRows, "Child records were requested");
        }

        protected abstract IModelWithChildrenScenario<TProductLine, TProduct> GetScenario();

        static void CompareLineAndProducts(int newKey, TProductLine line, TProductLine? echo)
        {
            Assert.IsNotNull(echo);
            Assert.AreEqual(newKey, echo!.ProductLineKey);
            Assert.AreEqual(line.ProductLineName, echo.ProductLineName);
            Assert.AreEqual(line.Products.Count, echo.Products.Count);

            foreach (var original in line.Products)
            {
                var copy = echo.Products.SingleOrDefault(x => x.ProductName == original.ProductName);
                Assert.IsNotNull(copy, "Child record not found");
                Assert.IsTrue(copy!.ProductKey >= 1000, "ProductKey under 1000 was not generated by the database");
                Assert.AreEqual(original.ProductWeight, copy.ProductWeight);
                Assert.AreEqual(original.ShippingWeight, copy.ShippingWeight);
            }
        }

        static TProductLine CreateProductLine(string? nameOverride = null)
        {
            var line = new TProductLine()
            {
                ProductLineName = nameOverride ?? "Test " + DateTime.Now.Ticks
            };
            for (var i = 0; i < 5; i++)
            {
                var product = new TProduct()
                {
                    ProductName = "Part " + Alpha[i],
                    ProductWeight = 123 + (i * .45M),
                    ShippingWeight = 125 + (i * .45M)
                };
                line.Products.Add(product);
            }

            return line;
        }
    }
}