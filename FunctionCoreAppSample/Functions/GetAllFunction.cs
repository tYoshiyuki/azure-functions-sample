using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace FunctionCoreAppSample.Functions
{
    /// <summary>
    /// GetAllFunctionクラス
    /// </summary>
    public class GetAllFunction : BaseHttpTrrigerFunction
    {
        /// <summary>
        /// 処理対象テーブルストレージのデータ
        /// </summary>
        public CloudTable InputTable { get; set; }

        public GetAllFunction(CloudTable inputTable, HttpRequestMessage request, ILogger log) : base(request, log)
        {
            InputTable = inputTable;
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

            // テーブルストレージよりデータを取得する
            var result = await InputTable.ExecuteQuerySegmentedAsync(new TableQuery(), null);
            Log.LogInformation($"取得件数:[{result.Count()}]");
            Response = Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
