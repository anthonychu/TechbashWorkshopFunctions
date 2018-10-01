using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;

namespace TechbashWorkshopFunctions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("reviews")]string myQueueItem, [Table("reviews")] out Review review, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            review = new Review
            {
                PartitionKey = "review",
                RowKey = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(),
                Text = myQueueItem
            };
        }
    }

    public class Review : TableEntity
    {
        public string Text { get; set; }
    }
}
