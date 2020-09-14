using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Threading.Tasks;

namespace TimerTriggerOrchestrator
{
    public static class Timer
    {
        [FunctionName("Timer")]
        public static async Task RunAsync(
            [TimerTrigger("*/10 * * * * * ")]TimerInfo myTimer,
            [DurableClient] IDurableOrchestrationClient client,
            ILogger log)
        {
            string instanceId = await client.StartNewAsync("Orchestrator");
            log.LogInformation($"Instance ID is {instanceId}");
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
