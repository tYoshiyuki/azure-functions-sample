using FunctionCoreAppSample.ApplicationInsights;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;

namespace FunctionCoreAppSample.Functions
{
    /// <summary>
    /// HttpTrrigerFunctionの基底クラス
    /// </summary>
    public class BaseHttpTrrigerFunction
    {
        public static ITelemetryClientFactory telemetryFactory = new TelemetryClientFactory();

        protected ILogger Log { get; }
        protected HttpRequestMessage Request { get; set; }
        protected HttpResponseMessage Response { get; set; }
        protected Stopwatch Sw { get; set; }

        public BaseHttpTrrigerFunction(HttpRequestMessage request, ILogger log)
        {
            Request = request;
            Log = log;
        }

        /// <summary>
        /// 事前処理
        /// </summary>
        protected virtual void Before()
        {
            Log.LogInformation("処理開始");

            // 処理時間計測
            Sw = new Stopwatch();
            Sw.Start();
        }

        /// <summary>
        /// 事後処理
        /// </summary>
        protected virtual void After()
        {
            // カスタムイベントを送信する
            var metrics = new Dictionary<string, double> { { "processingTime", Sw.Elapsed.TotalMilliseconds } };
            var tc = telemetryFactory.GetClient();
            tc.TrackEvent(GetType().FullName, metrics: metrics);

            Log.LogInformation("処理終了");
        }

        /// <summary>
        /// メイン処理
        /// </summary>
        protected virtual void Main()
        {
            Log.LogInformation("Main処理開始");
        }

        /// <summary>
        /// バッチ処理の実行
        /// </summary>
        public HttpResponseMessage Execute()
        {
            try
            {
                // 事前処理
                Before();

                // メイン処理
                Main();
            }
            catch (Exception ex)
            {
                Log.LogError("エラーが発生しました", ex);
                Response = Request.CreateResponse(HttpStatusCode.InternalServerError, "エラーが発生しました");
            }
            finally
            {
                // 事後処理
                After();
            }

            return Response;
        }

    }
}
