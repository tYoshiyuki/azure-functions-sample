using Microsoft.ApplicationInsights;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace FunctionAppSample.Extensions
{
    public static class CloudTableExtensions
    {
        public static void AddOrUpdate<T>(this CloudTable table, T data) where T : TableEntity
        {
            if (string.IsNullOrEmpty(data.RowKey)) data.RowKey = Guid.NewGuid().ToString();
            table.Execute(TableOperation.InsertOrReplace(data));
        }

        public static void Delete<T>(this CloudTable table, T data) where T : TableEntity
        {
            table.Execute(TableOperation.Delete(data));
        }
    }
}
