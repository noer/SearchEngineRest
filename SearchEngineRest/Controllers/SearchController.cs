using Microsoft.AspNetCore.Mvc;
using SearchEngineRest.Models;
using System.Collections.Generic;
using SearchEngineRest.Services;
using SearchEngineRest.Factories;
using System.Threading.Tasks;

namespace SearchEngineRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly IDocumentService docService;

        public SearchController(searchContext context)
        {
            docService = new ServiceFactory().getDocumentService(context);
        }

        // GET
        [HttpGet("{query}")]
        public async Task<IActionResult> SearchAsync(string query)
        {
            List<Document> strings = await docService.Search(query);
            if (strings != null && strings.Count > 0)
            {
                return Ok(strings);
            } else
            {
                return NotFound();
            }
        }
    }
}