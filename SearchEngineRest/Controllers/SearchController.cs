using Microsoft.AspNetCore.Mvc;
using SearchEngineRest.Models;
using System.Collections.Generic;
using SearchEngineRest.Services;
using SearchEngineRest.Factories;
using System.Threading.Tasks;
using System.Net;

namespace SearchEngineRest.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly IDocumentService docService;
        private readonly LogService logService;

        public SearchController(SearchContext context)
        {
            docService = new ServiceFactory().GetDocumentService(context);
            logService = new LogService(context);
        }

        // GET
        [HttpGet("{query}")]
        public async Task<IActionResult> SearchAsync(string query)
        {
            logService.logMessage(Dns.GetHostName(), getTimeNow(), "Received query for term " + query);
            List<Document> strings = await docService.Search(query);

            if (strings != null && strings.Count > 0)
            {
                logService.logMessage(Dns.GetHostName(), getTimeNow(), "Returning searchresult. " + strings.Count + " items for term " + query);
                return Ok(strings);
            } else
            {
                logService.logMessage(Dns.GetHostName(), getTimeNow(), "No result found for term " + query);
                return NotFound();
            }
        }

        private string getTimeNow()
        {
            return System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToLongTimeString();
        }
    }
}