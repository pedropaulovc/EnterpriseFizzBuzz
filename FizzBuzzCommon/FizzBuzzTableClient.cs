using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzCommon
{
    public abstract class FizzBuzzTableClient<T> where T : TableEntity, new()
    {
        private readonly CloudTableClient tableClient;
        private readonly string tableName;

        public FizzBuzzTableClient(CloudTableClient tableClient, string tableName)
        {
            this.tableClient = tableClient;
            this.tableName = tableName;
        }

        protected T Get(int number)
        {
            var query = new TableQuery<T>()
                .Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, number.ToString()));

            var queryResults = GetTable().ExecuteQuery(query);

            if (queryResults.Any())
            {
                return queryResults.First();
            }

            return null;
        }

        private CloudTable GetTable()
        {
            return this.tableClient.GetTableReference(this.tableName);
        }

        protected void Upsert(T entity)
        {
            this.GetTable().Execute(TableOperation.InsertOrReplace(entity));
        }
    }
}
