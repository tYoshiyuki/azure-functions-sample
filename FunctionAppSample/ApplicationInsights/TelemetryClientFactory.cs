using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using System;

namespace FunctionAppSample.ApplicationInsights
{
    public class TelemetryClientFactory : ITelemetryClientFactory
    {
        public virtual TelemetryClient GetClient()
        {
            var key = System.Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY", EnvironmentVariableTarget.Process);

            TelemetryClient client = new TelemetryClient();

            // 開発環境の場合はテレメトリの送信を抑止する
            if (!string.IsNullOrEmpty(key))
            {
                TelemetryConfiguration.Active.InstrumentationKey = key;
            }
            else
            {
                TelemetryConfiguration.Active.DisableTelemetry = true;
            }

            return client;
        }
    }

    public interface ITelemetryClientFactory
    {
        TelemetryClient GetClient();
    }
}
