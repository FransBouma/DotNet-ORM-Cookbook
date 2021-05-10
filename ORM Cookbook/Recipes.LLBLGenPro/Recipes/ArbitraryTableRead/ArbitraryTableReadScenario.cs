using Recipes.ArbitraryTableRead;
using System;
using System.Data;
using System.Data.Common;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Recipes.LLBLGenPro.ArbitraryTableRead
{
	public class ArbitraryTableReadScenario : IArbitraryTableReadScenario<DataTable>
	{
	    public DataTable GetAll(string schema, string tableName)
	    {
			using(var adapter = new DataAccessAdapter())
			{
				using var command = adapter.GetDbSpecificCreatorInstance().CreateCommand(adapter.GetConnection());
				// Don't do this. Research the schema, then build the code. Inlining input into a query is very dangerous!
				command.CommandText = $"SELECT * FROM [{schema}].[{tableName}];";
				command.Connection!.Open();
				using var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
				var result = new DataTable();
				result.Load(reader);
				return result;
			}
		}
	}
}
