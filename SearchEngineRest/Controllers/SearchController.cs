using Microsoft.AspNetCore.Mvc;
using SearchEngineRest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngineRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly searchContext _context;

        public SearchController(searchContext context)
        {
            _context = context;
        }
        
        // GET
        [HttpGet("{q}")]
        public Document Search(int q)
        {
            var doc = _context.Document.Find(q);
            return doc;
        }
        
        public string Index()
        {
            return "hej";
        }

    }
}