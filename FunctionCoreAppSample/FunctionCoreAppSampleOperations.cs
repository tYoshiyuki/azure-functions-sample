using FunctionCoreAppSample.Functions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System.Linq;
using System.Net.Http;

namespace FunctionCoreAppSample
{
    public static class FunctionCoreAppSampleOperations
    {
        [FunctionName("getall")]
        public static HttpResponseMessage GetAll([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, [Table("sampletable")]CloudTable inputTable, ILogger log)
        { 
            return new GetAllFunction(inputTable, req, log).Execute();
        }

        [FunctionName("addtable")]
        public static HttpResponseMessage AddTable([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, [Table("sampletable")]CloudTable table, ILogger log)
        {
            return new AddTableFunction(table, req, log).Execute();
        }
    }
}
