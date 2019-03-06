using SearchEngineRest.Models;
using SearchEngineRest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngineRest.Factories
{
    public class ServiceFactory
    {
        private IDocumentService documentService;

        public IDocumentService GetDocumentService(SearchContext context)
        {
            if (documentService == null)
            {
                documentService = new DocumentService(context);
            }
            return documentService;
        }
    }
}
