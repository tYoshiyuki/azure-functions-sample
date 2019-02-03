using Microsoft.ApplicationInsights;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace FunctionCoreAppSample.Extensions
{
    public static class CloudTableExtensions
    {
        public static async System.Threading.Tasks.Task AddOrUpdateAsync<T>(this CloudTable table, T data) where T : TableEntity
        {
            if (string.IsNullOrEmpty(data.RowKey)) data.RowKey = Guid.NewGuid().ToString();
            await table.ExecuteAsync(TableOperation.InsertOrReplace(data));
        }

        public static async System.Threading.Tasks.Task DeleteAsync<T>(this CloudTable table, T data) where T : TableEntity
        {
            await table.ExecuteAsync(TableOperation.Delete(data));
        }
    }
}
