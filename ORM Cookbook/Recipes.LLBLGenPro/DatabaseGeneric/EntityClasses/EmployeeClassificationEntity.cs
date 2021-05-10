﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.8.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.FactoryClasses;
using LLBLGenPro.OrmCookbook.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace LLBLGenPro.OrmCookbook.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Entity class which represents the entity 'EmployeeClassification'.<br/><br/></summary>
	[Serializable]
	public partial class EmployeeClassificationEntity : CommonEntityBase, Recipes.IEmployeeClassification
    // __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
    // __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private EntityCollection<EmployeeEntity> _employees;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static EmployeeClassificationEntityStaticMetaData _staticMetaData = new EmployeeClassificationEntityStaticMetaData();
		private static EmployeeClassificationRelations _relationsFactory = new EmployeeClassificationRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Employees</summary>
			public static readonly string Employees = "Employees";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class EmployeeClassificationEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public EmployeeClassificationEntityStaticMetaData()
			{
				SetEntityCoreInfo("EmployeeClassificationEntity", InheritanceHierarchyType.None, false, (int)LLBLGenPro.OrmCookbook.EntityType.EmployeeClassificationEntity, typeof(EmployeeClassificationEntity), typeof(EmployeeClassificationEntityFactory), false);
				AddNavigatorMetaData<EmployeeClassificationEntity, EntityCollection<EmployeeEntity>>("Employees", a => a._employees, (a, b) => a._employees = b, a => a.Employees, () => new EmployeeClassificationRelations().EmployeeEntityUsingEmployeeClassificationKey, typeof(EmployeeEntity), (int)LLBLGenPro.OrmCookbook.EntityType.EmployeeEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static EmployeeClassificationEntity()
		{
		}

		/// <summary> CTor</summary>
		public EmployeeClassificationEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EmployeeClassificationEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EmployeeClassificationEntity</param>
		public EmployeeClassificationEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="employeeClassificationKey">PK value for EmployeeClassification which data should be fetched into this EmployeeClassification object</param>
		public EmployeeClassificationEntity(System.Int32 employeeClassificationKey) : this(employeeClassificationKey, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="employeeClassificationKey">PK value for EmployeeClassification which data should be fetched into this EmployeeClassification object</param>
		/// <param name="validator">The custom validator object for this EmployeeClassificationEntity</param>
		public EmployeeClassificationEntity(System.Int32 employeeClassificationKey, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.EmployeeClassificationKey = employeeClassificationKey;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected EmployeeClassificationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Method which will construct a filter (predicate expression) for the unique constraint defined on the fields: EmployeeClassificationName .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCEmployeeClassificationName()
		{
			var filter = new PredicateExpression();
			filter.Add(LLBLGenPro.OrmCookbook.HelperClasses.EmployeeClassificationFields.EmployeeClassificationName == this.Fields.GetCurrentValue((int)EmployeeClassificationFieldIndex.EmployeeClassificationName));
 			return filter;
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Employee' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmployees() { return CreateRelationInfoForNavigator("Employees"); }
		
		/// <inheritdoc/>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() {	return _staticMetaData; }

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{
			PerformDependencyInjection();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this EmployeeClassificationEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public static EmployeeClassificationRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Employee' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmployees { get { return _staticMetaData.GetPrefetchPathElement("Employees", CommonEntityBase.CreateEntityCollection<EmployeeEntity>()); } }

		/// <summary>The EmployeeClassificationKey property of the Entity EmployeeClassification<br/><br/></summary>
		/// <remarks>Mapped on  table field: "EmployeeClassification"."EmployeeClassificationKey".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 EmployeeClassificationKey
		{
			get { return (System.Int32)GetValue((int)EmployeeClassificationFieldIndex.EmployeeClassificationKey, true); }
			set { SetValue((int)EmployeeClassificationFieldIndex.EmployeeClassificationKey, value); }		}

		/// <summary>The EmployeeClassificationName property of the Entity EmployeeClassification<br/><br/></summary>
		/// <remarks>Mapped on  table field: "EmployeeClassification"."EmployeeClassificationName".<br/>Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 30.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String EmployeeClassificationName
		{
			get { return (System.String)GetValue((int)EmployeeClassificationFieldIndex.EmployeeClassificationName, true); }
			set	{ SetValue((int)EmployeeClassificationFieldIndex.EmployeeClassificationName, value); }
		}

		/// <summary>The IsEmployee property of the Entity EmployeeClassification<br/><br/></summary>
		/// <remarks>Mapped on  table field: "EmployeeClassification"."IsEmployee".<br/>Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsEmployee
		{
			get { return (System.Boolean)GetValue((int)EmployeeClassificationFieldIndex.IsEmployee, true); }
			set	{ SetValue((int)EmployeeClassificationFieldIndex.IsEmployee, value); }
		}

		/// <summary>The IsExempt property of the Entity EmployeeClassification<br/><br/></summary>
		/// <remarks>Mapped on  table field: "EmployeeClassification"."IsExempt".<br/>Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsExempt
		{
			get { return (System.Boolean)GetValue((int)EmployeeClassificationFieldIndex.IsExempt, true); }
			set	{ SetValue((int)EmployeeClassificationFieldIndex.IsExempt, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'EmployeeEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(EmployeeEntity))]
		public virtual EntityCollection<EmployeeEntity> Employees { get { return GetOrCreateEntityCollection<EmployeeEntity, EmployeeEntityFactory>("EmployeeClassification", true, false, ref _employees); } }

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace LLBLGenPro.OrmCookbook
{
	public enum EmployeeClassificationFieldIndex
	{
		///<summary>EmployeeClassificationKey. </summary>
		EmployeeClassificationKey,
		///<summary>EmployeeClassificationName. </summary>
		EmployeeClassificationName,
		///<summary>IsEmployee. </summary>
		IsEmployee,
		///<summary>IsExempt. </summary>
		IsExempt,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace LLBLGenPro.OrmCookbook.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: EmployeeClassification. </summary>
	public partial class EmployeeClassificationRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between EmployeeClassificationEntity and EmployeeEntity over the 1:n relation they have, using the relation between the fields: EmployeeClassification.EmployeeClassificationKey - Employee.EmployeeClassificationKey</summary>
		public virtual IEntityRelation EmployeeEntityUsingEmployeeClassificationKey
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "Employees", true, new[] { EmployeeClassificationFields.EmployeeClassificationKey, EmployeeFields.EmployeeClassificationKey }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticEmployeeClassificationRelations
	{
		internal static readonly IEntityRelation EmployeeEntityUsingEmployeeClassificationKeyStatic = new EmployeeClassificationRelations().EmployeeEntityUsingEmployeeClassificationKey;

		/// <summary>CTor</summary>
		static StaticEmployeeClassificationRelations() { }
	}
}
