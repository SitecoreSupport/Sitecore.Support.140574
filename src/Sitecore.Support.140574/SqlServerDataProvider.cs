using Sitecore.Data.DataProviders.Sql.FastQuery;

namespace Sitecore.Support.Data.SqlServer
{

    public class SqlServerDataProvider : Sitecore.Data.SqlServer.SqlServerDataProvider
    {

        public SqlServerDataProvider(string connectionString) : base(connectionString)
        {
        }

        // Overriding the SqlServerQueryToSqlTranslator class 
        // This class is used during fast query processing
        protected override QueryToSqlTranslator CreateSqlTranslator() =>
            new Sitecore.Support.Data.DataProviders.Sql.FastQuery.SqlServerQueryToSqlTranslator(base.Api);
    }
}
