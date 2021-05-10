﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.8.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.RelationClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace LLBLGenPro.OrmCookbook.FactoryClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>general base class for the generated factories</summary>
	[Serializable]
	public partial class EntityFactoryBase2<TEntity> : EntityFactoryCore2
		where TEntity : EntityBase2, IEntity2
	{
		private readonly LLBLGenPro.OrmCookbook.EntityType _typeOfEntity;
		private readonly bool _isInHierarchy;

		/// <summary>CTor</summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <param name="isInHierarchy">If true, the entity of this factory is in an inheritance hierarchy, false otherwise</param>
		public EntityFactoryBase2(string entityName, LLBLGenPro.OrmCookbook.EntityType typeOfEntity, bool isInHierarchy) : base(entityName)
		{
			_typeOfEntity = typeOfEntity;
			_isInHierarchy = isInHierarchy;
		}
		
		/// <inheritdoc/>
		public override IEntityFields2 CreateFields() { return ModelInfoProviderSingleton.GetInstance().GetEntityFields(this.ForEntityName); }
		
		/// <inheritdoc/>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue) {	return GeneralEntityFactory.Create((LLBLGenPro.OrmCookbook.EntityType)entityTypeValue); }

		/// <inheritdoc/>
		public override IRelationCollection CreateHierarchyRelations(string objectAlias) { return ModelInfoProviderSingleton.GetInstance().GetHierarchyRelations(this.ForEntityName, objectAlias); }

		/// <inheritdoc/>
		public override IEntityFactory2 GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity) 
		{
			return (IEntityFactory2)ModelInfoProviderSingleton.GetInstance().GetEntityFactory(this.ForEntityName, fieldValues, entityFieldStartIndexesPerEntity) ?? this;
		}
		
		/// <inheritdoc/>
		public override IPredicateExpression GetEntityTypeFilter(bool negate, string objectAlias) {	return ModelInfoProviderSingleton.GetInstance().GetEntityTypeFilter(this.ForEntityName, objectAlias, negate);	}
						
		/// <inheritdoc/>
		public override IEntityCollection2 CreateEntityCollection()	{ return new EntityCollection<TEntity>(this); }
		
		/// <inheritdoc/>
		public override IEntityFields2 CreateHierarchyFields() 
		{
			return _isInHierarchy ? new EntityFields2(ModelInfoProviderSingleton.GetInstance().GetHierarchyFields(this.ForEntityName), ModelInfoProviderSingleton.GetInstance(), null) : base.CreateHierarchyFields();
		}
		
		/// <inheritdoc/>
		protected override Type ForEntityType { get { return typeof(TEntity); } }
	}

	/// <summary>Factory to create new, empty DepartmentEntity objects.</summary>
	[Serializable]
	public partial class DepartmentEntityFactory : EntityFactoryBase2<DepartmentEntity> 
	{
		/// <summary>CTor</summary>
		public DepartmentEntityFactory() : base("DepartmentEntity", LLBLGenPro.OrmCookbook.EntityType.DepartmentEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new DepartmentEntity(fields); }
	}

	/// <summary>Factory to create new, empty DivisionEntity objects.</summary>
	[Serializable]
	public partial class DivisionEntityFactory : EntityFactoryBase2<DivisionEntity> 
	{
		/// <summary>CTor</summary>
		public DivisionEntityFactory() : base("DivisionEntity", LLBLGenPro.OrmCookbook.EntityType.DivisionEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new DivisionEntity(fields); }
	}

	/// <summary>Factory to create new, empty EmployeeEntity objects.</summary>
	[Serializable]
	public partial class EmployeeEntityFactory : EntityFactoryBase2<EmployeeEntity> 
	{
		/// <summary>CTor</summary>
		public EmployeeEntityFactory() : base("EmployeeEntity", LLBLGenPro.OrmCookbook.EntityType.EmployeeEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new EmployeeEntity(fields); }
	}

	/// <summary>Factory to create new, empty EmployeeClassificationEntity objects.</summary>
	[Serializable]
	public partial class EmployeeClassificationEntityFactory : EntityFactoryBase2<EmployeeClassificationEntity> 
	{
		/// <summary>CTor</summary>
		public EmployeeClassificationEntityFactory() : base("EmployeeClassificationEntity", LLBLGenPro.OrmCookbook.EntityType.EmployeeClassificationEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new EmployeeClassificationEntity(fields); }
	}

	/// <summary>Factory to create new, empty EmployeeDetailEntity objects.</summary>
	[Serializable]
	public partial class EmployeeDetailEntityFactory : EntityFactoryBase2<EmployeeDetailEntity> 
	{
		/// <summary>CTor</summary>
		public EmployeeDetailEntityFactory() : base("EmployeeDetailEntity", LLBLGenPro.OrmCookbook.EntityType.EmployeeDetailEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new EmployeeDetailEntity(fields); }
	}

	/// <summary>Factory to create new, empty ProductEntity objects.</summary>
	[Serializable]
	public partial class ProductEntityFactory : EntityFactoryBase2<ProductEntity> 
	{
		/// <summary>CTor</summary>
		public ProductEntityFactory() : base("ProductEntity", LLBLGenPro.OrmCookbook.EntityType.ProductEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new ProductEntity(fields); }
	}

	/// <summary>Factory to create new, empty ProductLineEntity objects.</summary>
	[Serializable]
	public partial class ProductLineEntityFactory : EntityFactoryBase2<ProductLineEntity> 
	{
		/// <summary>CTor</summary>
		public ProductLineEntityFactory() : base("ProductLineEntity", LLBLGenPro.OrmCookbook.EntityType.ProductLineEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new ProductLineEntity(fields); }
	}

	/// <summary>Factory to create new, empty Entity objects based on the entity type specified. Uses  entity specific factory objects</summary>
	[Serializable]
	public partial class GeneralEntityFactory
	{
		/// <summary>Creates a new, empty Entity object of the type specified</summary>
		/// <param name="entityTypeToCreate">The entity type to create.</param>
		/// <returns>A new, empty Entity object.</returns>
		public static IEntity2 Create(LLBLGenPro.OrmCookbook.EntityType entityTypeToCreate)
		{
			var factoryToUse = EntityFactoryFactory.GetFactory(entityTypeToCreate);
			IEntity2 toReturn = null;
			if(factoryToUse != null)
			{
				toReturn = factoryToUse.Create();
			}
			return toReturn;
		}		
	}
		
	/// <summary>Class which is used to obtain the entity factory based on the .NET type of the entity. </summary>
	[Serializable]
	public static class EntityFactoryFactory
	{
		private static Dictionary<Type, IEntityFactory2> _factoryPerType = new Dictionary<Type, IEntityFactory2>();

		/// <summary>Initializes the <see cref="EntityFactoryFactory"/> class.</summary>
		static EntityFactoryFactory()
		{
			foreach(int entityTypeValue in Enum.GetValues(typeof(LLBLGenPro.OrmCookbook.EntityType)))
			{
				var factory = GetFactory((LLBLGenPro.OrmCookbook.EntityType)entityTypeValue);
				_factoryPerType.Add(factory.ForEntityType ?? factory.Create().GetType(), factory);
			}
		}

		/// <summary>Gets the factory of the entity with the .NET type specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(Type typeOfEntity) { return _factoryPerType.GetValue(typeOfEntity); }

		/// <summary>Gets the factory of the entity with the LLBLGenPro.OrmCookbook.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(LLBLGenPro.OrmCookbook.EntityType typeOfEntity)
		{
			switch(typeOfEntity)
			{
				case LLBLGenPro.OrmCookbook.EntityType.DepartmentEntity:
					return new DepartmentEntityFactory();
				case LLBLGenPro.OrmCookbook.EntityType.DivisionEntity:
					return new DivisionEntityFactory();
				case LLBLGenPro.OrmCookbook.EntityType.EmployeeEntity:
					return new EmployeeEntityFactory();
				case LLBLGenPro.OrmCookbook.EntityType.EmployeeClassificationEntity:
					return new EmployeeClassificationEntityFactory();
				case LLBLGenPro.OrmCookbook.EntityType.EmployeeDetailEntity:
					return new EmployeeDetailEntityFactory();
				case LLBLGenPro.OrmCookbook.EntityType.ProductEntity:
					return new ProductEntityFactory();
				case LLBLGenPro.OrmCookbook.EntityType.ProductLineEntity:
					return new ProductLineEntityFactory();
				default:
					return null;
			}
		}
	}
		
	/// <summary>Element creator for creating project elements from somewhere else, like inside Linq providers.</summary>
	public class ElementCreator : ElementCreatorBase, IElementCreator2
	{
		/// <summary>Gets the factory of the Entity type with the LLBLGenPro.OrmCookbook.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(int entityTypeValue) { return (IEntityFactory2)this.GetFactoryImpl(entityTypeValue); }
		
		/// <summary>Gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(Type typeOfEntity) { return (IEntityFactory2)this.GetFactoryImpl(typeOfEntity); }

		/// <summary>Creates a new resultset fields object with the number of field slots reserved as specified</summary>
		/// <param name="numberOfFields">The number of fields.</param>
		/// <returns>ready to use resultsetfields object</returns>
		public IEntityFields2 CreateResultsetFields(int numberOfFields) { return new ResultsetFields(numberOfFields); }
		
		/// <inheritdoc/>
		public override IInheritanceInfoProvider ObtainInheritanceInfoProviderInstance() { return ModelInfoProviderSingleton.GetInstance(); }

		/// <inheritdoc/>
		public override IEntityFieldsCore GetTypedViewFields(int typedViewTypeEnumValue) { return ModelInfoProviderSingleton.GetInstance().GetTypedViewFields(((TypedViewType)typedViewTypeEnumValue).ToString()); }

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand) { return new DynamicRelation(leftOperand); }

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(IEntityFieldCore leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, string aliasLeftOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, aliasLeftOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (LLBLGenPro.OrmCookbook.EntityType)Enum.Parse(typeof(LLBLGenPro.OrmCookbook.EntityType), rightOperandEntityName, false), aliasRightOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(string leftOperandEntityName, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation((LLBLGenPro.OrmCookbook.EntityType)Enum.Parse(typeof(LLBLGenPro.OrmCookbook.EntityType), leftOperandEntityName, false), joinType, (LLBLGenPro.OrmCookbook.EntityType)Enum.Parse(typeof(LLBLGenPro.OrmCookbook.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(IEntityFieldCore leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (LLBLGenPro.OrmCookbook.EntityType)Enum.Parse(typeof(LLBLGenPro.OrmCookbook.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <inheritdoc/>
		protected override IEntityFactoryCore GetFactoryImpl(int entityTypeValue) { return EntityFactoryFactory.GetFactory((LLBLGenPro.OrmCookbook.EntityType)entityTypeValue); }

		/// <inheritdoc/>
		protected override IEntityFactoryCore GetFactoryImpl(Type typeOfEntity) { return EntityFactoryFactory.GetFactory(typeOfEntity);	}

	}
}
