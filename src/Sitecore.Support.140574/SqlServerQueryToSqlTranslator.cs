using Sitecore.Data.DataProviders.Sql;
using System.Text;

namespace Sitecore.Support.Data.DataProviders.Sql.FastQuery
{

    public class SqlServerQueryToSqlTranslator : Sitecore.Data.DataProviders.Sql.FastQuery.SqlServerQueryToSqlTranslator
    {
        public SqlServerQueryToSqlTranslator(SqlDataApi api) : base(api)
        {
        }

        protected override void AddNameFilter(string name, StringBuilder builder)
        {
            if (MainUtil.IsID(name))
            {
                builder.Append(this._api.Format("{0}i{1}.{0}ID{1}"));
            }
            else
            {
                builder.Append(this._api.Format("LOWER({0}i{1}.{0}Name{1})"));
                name = name.ToLowerInvariant();
            }

            // Added 'N' character to the SQL query to enable the processing of unicode characters
            builder.Append(" = N'" + this._api.Safe(name) + "'");
        }

    }
}
