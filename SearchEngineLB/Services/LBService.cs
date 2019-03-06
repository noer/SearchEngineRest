using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngineLB.Services
{
    public class LBService
    {
        private List<string> searchServices;
        private int nextService = 0;

        public LBService()
        {
            searchServices = new List<string>();
            searchServices.Add("http://searchenginerest:80/api/search/");
            searchServices.Add("http://searchenginerest1:80/api/search/");
        }

        public string GetNextURL()
        {
            if (nextService >= searchServices.Count)
            {
                nextService = 0;
            }
            string url = searchServices[nextService];
            nextService++;
            return url;
        }
    }
}
