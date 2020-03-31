using System;
using System.Data;
using System.Data.SQLite;
using System.Configuration.Assemblies;
using System.Configuration;

namespace ConnectionUtils
{
	public class SqliteConnectionFactory : ConnectionFactory
	{
		public override IDbConnection createConnection()
		{
			string returnValue = null;
			ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["MyDBConnectionString"];
		    if (settings != null)
				returnValue = settings.ConnectionString;
			return new SQLiteConnection(returnValue);
		
		}
	}
}
