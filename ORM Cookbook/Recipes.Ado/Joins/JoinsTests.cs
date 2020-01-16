﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Joins;

namespace Recipes.Ado.Joins
{
    [TestClass]
    public class JoinsTests : JoinsTests<EmployeeDetail, EmployeeSimple>
    {
        protected override IJoinsScenario<EmployeeDetail, EmployeeSimple> GetScenario()
        {
            return new JoinsScenario(Setup.ConnectionString);
        }
    }
}