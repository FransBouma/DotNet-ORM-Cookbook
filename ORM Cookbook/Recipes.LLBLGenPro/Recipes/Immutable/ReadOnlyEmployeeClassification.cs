﻿using Recipes.Immutable;
using System;
using LLBLGenPro.OrmCookbook.EntityClasses;

namespace Recipes.LLBLGenPro.Immutable
{
    public class ReadOnlyEmployeeClassification : IReadOnlyEmployeeClassification
    {
        public ReadOnlyEmployeeClassification(EmployeeClassificationEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), $"{nameof(entity)} is null.");
            if (entity.EmployeeClassificationName == null)
                throw new ArgumentNullException(nameof(entity), $"{nameof(entity.EmployeeClassificationName)} is null.");

            EmployeeClassificationKey = entity.EmployeeClassificationKey;
            EmployeeClassificationName = entity.EmployeeClassificationName;
            IsExempt = entity.IsExempt;
            IsEmployee = entity.IsEmployee;
        }

        public ReadOnlyEmployeeClassification(int employeeClassificationKey, string employeeClassificationName, bool isExempt, bool isEmployee)
        {
            EmployeeClassificationKey = employeeClassificationKey;
            EmployeeClassificationName = employeeClassificationName;
            IsExempt = isExempt;
            IsEmployee = isEmployee;
        }

        public EmployeeClassificationEntity ToEntity()
        {
            return new EmployeeClassificationEntity()
            {
                EmployeeClassificationKey = EmployeeClassificationKey,
                EmployeeClassificationName = EmployeeClassificationName,
                IsExempt = IsExempt,
                IsEmployee = IsEmployee
            };
        }

        public int EmployeeClassificationKey { get; }
        public string EmployeeClassificationName { get; }
        public bool IsExempt { get; }
        public bool IsEmployee { get; }
    }
}