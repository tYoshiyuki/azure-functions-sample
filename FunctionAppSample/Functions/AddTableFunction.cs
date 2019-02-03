using FunctionAppSample.Extensions;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;
using System.Net;
using System.Net.Http;

namespace FunctionAppSample.Functions
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

        public AddTableFunction(CloudTable table, HttpRequestMessage request, TraceWriter log) : base(request, log)
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

        protected override void Main()
        {
            base.Main();

            // テーブルストレージにデータを登録する
            Table.AddOrUpdate(new TableEntity { PartitionKey = "" });
            Response = Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

    }
}
