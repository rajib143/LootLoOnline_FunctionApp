using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using LootLoOnline_FunctionApp.Repository;

namespace LootLoOnline_FunctionApp
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {

                var lootLoOnlineDbContext = new LootLoOnlineDbContext();
                OfferProductRepository offerProductRepository = new OfferProductRepository(lootLoOnlineDbContext);

                var result = await offerProductRepository.GetAllByFilter(1,100,x=>x.shotTitle.Contains("50"), x=>x.SpecialPrice);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult(ex);
            }
        }
    }
}
