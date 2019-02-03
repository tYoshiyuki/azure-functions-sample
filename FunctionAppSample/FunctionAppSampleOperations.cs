using FunctionAppSample.ApplicationInsights;
using FunctionAppSample.Functions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;
using System.Linq;
using System.Net.Http;

namespace FunctionAppSample
{
    public static class FunctionAppSampleOperations
    {
        [FunctionName("getall")]
        public static HttpResponseMessage GetAll([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, [Table("sampletable", Connection = "AzureWebJobsStorage")]IQueryable<TableEntity> inputTable, TraceWriter log)
        {
            return new GetAllFunction(inputTable, req, log).Execute();
        }

        [FunctionName("addtable")]
        public static HttpResponseMessage AddTable([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, [Table("sampletable", Connection = "AzureWebJobsStorage")]CloudTable table, TraceWriter log)
        {
            return new AddTableFunction(table, req, log).Execute();
        }
    }
}
