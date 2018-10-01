using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;

namespace TechbashWorkshopFunctions
{
    public static class GetReviews
    {
        [FunctionName("GetReviews")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, 
            [Table("reviews")] CloudTable reviews,
            ILogger log)
        {
            var items = await reviews.ExecuteQuerySegmentedAsync(new TableQuery<Review>(), null);
            return new OkObjectResult(items.Results.ToList());
        }
    }
}
