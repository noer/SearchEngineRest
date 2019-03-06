using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngineRest.Models
{
    public class LogItem
    {
        public int id { get; set; }
        public string hostname { get; set; }
        public string timestamp { get; set; }
        public string message { get; set; }

        public LogItem(string hostname, string timestamp, string message)
        {
            this.hostname = hostname;
            this.timestamp = timestamp;
            this.message = message;
        }
    }
}
