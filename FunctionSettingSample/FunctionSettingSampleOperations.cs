using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using FunctionSettingSample.Configs;

namespace FunctionSettingSample
{
    public class FunctionSettingSampleOperations
    {
        private readonly AppConfig _appConfig;

        public FunctionSettingSampleOperations(IOptions<AppConfig> appConfig)
        {
            _appConfig = appConfig.Value;
        }

        [FunctionName("index")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            log.LogInformation($"Settings Test01 {_appConfig.Props.First}.");
            log.LogInformation($"Settings Test02 {_appConfig.Props.Second}.");

            return new OkObjectResult($"Hello, {_appConfig.Name}");
        }
    }
}
