using SearchEngineRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngineRest.Services
{
    public class LogService
    {
        private readonly SearchContext _context;

        public LogService(SearchContext context)
        {
            _context = context;
        }

        public void logMessage(LogItem logItem)
        {
            _context.LogItem.Add(logItem);
            _context.SaveChanges();
        }

        public void logMessage(string hostname, string timestamp, string message)
        {
            logMessage(new LogItem(hostname, timestamp, message));
        }
    }
}
