using SearchEngineRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngineRest.Services
{
    public interface IDocumentService
    {
        Task<List<Document>> Search(string query);
    }
}
