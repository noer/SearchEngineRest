using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SearchEngineRest.Models;

namespace SearchEngineRest.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly SearchContext _context;

        public DocumentService(SearchContext context)
        {
            _context = context;
        }

        public async Task<List<Document>> Search(string query)
        {
            var term = await _context.Term.Where(t => t.Value.Equals(query)).SingleOrDefaultAsync();
            if (term == null) { return null; }
            List<TermDoc> termDocs = await _context.TermDoc.Where(td => td.Termid == term.Id).Take(10).ToListAsync();
            List<Document> docs = new List<Document>();
            foreach (TermDoc termDoc in termDocs)
            {
                docs.Add(await _context.Document.Where(d => d.Id == termDoc.Docid).SingleOrDefaultAsync());
            }

            return docs;
        }
    }
}
