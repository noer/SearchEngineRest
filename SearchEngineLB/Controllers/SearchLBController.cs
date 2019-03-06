using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using SearchEngineLB.Services;

namespace SearchEngineLB.Controllers
{
    [Route("api/searchlb")]
    [ApiController]
    public class SearchLBController : ControllerBase
    {
        private LBService lbService;

        public SearchLBController(LBService lbService)
        {
            this.lbService = lbService;
        }

        // GET
        [HttpGet("{query}")]
        public async Task<IActionResult> SearchAsync(string query)
        {
            string url = lbService.GetNextURL();
            Console.WriteLine("URL: " + url);

            RestClient rc = new RestClient
            {
                BaseUrl = new Uri(url)
            };

            RestRequest rq = new RestRequest(query, Method.GET);

            var response = await rc.ExecuteTaskAsync(rq);

            if (response != null)
            {
                return Ok(response.Content + response.ResponseUri);
            }
            else
            {
                return NotFound();
            }
        }
    }
}