namespace PuppeteerAzureFunc.Examples
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using PuppeteerSharp;

    public static class Title
    {
        [FunctionName("Examples-Title")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Examples/Title")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string url = req.Query["url"];

            if (string.IsNullOrWhiteSpace(url))
                return new BadRequestObjectResult("Please pass a url on the query string or in the request body");

            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Args = new[] { "--no-sandbox" },
                Headless = true,
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync(url);
            var title = await page.GetTitleAsync();
            await browser.CloseAsync();

            return new OkObjectResult(title);
        }
    }
}
