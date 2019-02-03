using FunctionCoreAppSample.Extensions;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace FunctionCoreAppSample.Functions
{
    /// <summary>
    /// AddTableFunctionクラス
    /// </summary>
    public class AddTableFunction : BaseHttpTrrigerFunction
    {
        /// <summary>
        /// 処理対象テーブルストレージ
        /// </summary>
        public CloudTable Table { get; set; }

        public AddTableFunction(CloudTable table, HttpRequestMessage request, ILogger log) : base(request, log)
        {
            Table = table;
        }

        protected override void Before()
        {
            base.Before();
        }

        protected override void After()
        {
            base.After();
        }

        protected override async void Main()
        {
            base.Main();

            // テーブルストレージにデータを登録する
            await Table.AddOrUpdateAsync(new TableEntity { PartitionKey = "" });
            Response = Request.CreateResponse(HttpStatusCode.OK, "Success");
        }
    }
}
