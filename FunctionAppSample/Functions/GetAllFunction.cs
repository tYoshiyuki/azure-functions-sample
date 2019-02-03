using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace FunctionAppSample.Functions
{
    /// <summary>
    /// GetAllFunctionクラス
    /// </summary>
    public class GetAllFunction : BaseHttpTrrigerFunction
    {
        /// <summary>
        /// 処理対象テーブルストレージのデータ
        /// </summary>
        public IQueryable<TableEntity> InputTable { get; set; }

        public GetAllFunction(IQueryable<TableEntity> inputTable, HttpRequestMessage request, TraceWriter log) : base(request, log)
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

        protected override void Main()
        {
            base.Main();

            // テーブルストレージよりデータを取得する
            var result = InputTable.ToList();
            Log.Info($"取得件数:[{result.Count()}]");
            Response = Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
