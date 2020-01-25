﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.MultipleCrud
{
    /// <summary>
    /// This scenario works with collections of objects.
    /// </summary>
    [TestCategory("MultipleCrud")]
    public abstract class MultipleCrudTests<TEmployeeSimple> : TestBase
       where TEmployeeSimple : class, IEmployeeSimple, new()
    {
        const int RowCount = 100;

        [TestMethod]
        public void DeleteBatch()
        {
            var repository = GetScenario();

            var batchKey = Guid.NewGuid().ToString();
            var originals = BuildEmployees(RowCount, batchKey);
            var echoes = repository.InsertBatchReturnRows(originals);

            repository.DeleteBatch(echoes);

            var actuals = repository.FindByLastName(batchKey);

            Assert.AreEqual(0, actuals.Count);
        }

        [TestMethod]
        public void DeleteBatchByKey()
        {
            var repository = GetScenario();

            var batchKey = Guid.NewGuid().ToString();
            var originals = BuildEmployees(RowCount, batchKey);
            var keys = repository.InsertBatchReturnKeys(originals);

            repository.DeleteBatchByKey(keys);
            var actuals = repository.FindByLastName(batchKey);

            Assert.AreEqual(0, actuals.Count);
        }

        [TestMethod]
        public void InsertBatch()
        {
            var repository = GetScenario();

            var batchKey = Guid.NewGuid().ToString();
            var originals = BuildEmployees(RowCount, batchKey);
            repository.InsertBatch(originals);

            var actuals = repository.FindByLastName(batchKey);

            CompareLists(originals, actuals);
        }

        [TestMethod]
        public void InsertBatchReturnKeys()
        {
            var repository = GetScenario();

            var batchKey = Guid.NewGuid().ToString();
            var originals = BuildEmployees(RowCount, batchKey);
            var keys = repository.InsertBatchReturnKeys(originals);

            var actuals = repository.FindByLastName(batchKey);

            foreach (var key in keys)
                Assert.IsTrue(actuals.Any(x => x.EmployeeKey == key));

            CompareLists(originals, actuals);
        }

        [TestMethod]
        public void InsertBatchReturnRows()
        {
            var repository = GetScenario();

            var batchKey = Guid.NewGuid().ToString();
            var originals = BuildEmployees(RowCount, batchKey);
            var actuals = repository.InsertBatchReturnRows(originals);

            CompareLists(originals, actuals);
        }

        [TestMethod]
        public void InsertBatchWithUpdate()
        {
            var repository = GetScenario();

            var batchKey = Guid.NewGuid().ToString();
            var originals = BuildEmployees(RowCount, batchKey);
            repository.InsertBatchWithRefresh(originals);

            foreach (var original in originals)
                Assert.IsTrue(original.EmployeeKey >= 1000, "keys under 1000 were not generated by the database");
        }

        [TestMethod]
        public void UpdateBatch()
        {
            var repository = GetScenario();

            var batchKey = Guid.NewGuid().ToString();
            var originals = BuildEmployees(RowCount, batchKey);
            var actuals = repository.InsertBatchReturnRows(originals);

            CompareLists(originals, actuals);

            foreach (var item in actuals)
                item.FirstName = item.FirstName!.Replace("Test", "Updated ");

            repository.UpdateBatch(actuals);
            var updated = repository.FindByLastName(batchKey);

            CompareLists(actuals, updated);
        }

        protected abstract IMultipleCrudScenario<TEmployeeSimple> GetScenario();

        static IList<TEmployeeSimple> BuildEmployees(int count, string batchKey)
        {
            var result = new List<TEmployeeSimple>();
            for (var i = 0; i < count; i++)
            {
                result.Add(new TEmployeeSimple
                {
                    FirstName = "Test " + (i % 3),
                    MiddleName = "A" + i,
                    LastName = batchKey,
                    EmployeeClassificationKey = (i % 7) + 1
                });
            }
            return result;
        }

        private static void CompareLists(IList<TEmployeeSimple> originals, IList<TEmployeeSimple> actuals)
        {
            Assert.AreEqual(originals.Count, actuals.Count, "Wrong number of rows created or returned");
            foreach (var original in originals)
            {
                var actual = actuals.Single(x => x.MiddleName == original.MiddleName);
                Assert.IsTrue(actual.EmployeeKey >= 1000, "keys under 1000 were not generated by the database");
                Assert.AreEqual(original.FirstName, actual.FirstName);
                //Assert.AreEqual(original.MiddleName, actual.MiddleName);
                Assert.AreEqual(original.LastName, actual.LastName);
                Assert.AreEqual(original.EmployeeClassificationKey, actual.EmployeeClassificationKey);
            }
        }
    }
}