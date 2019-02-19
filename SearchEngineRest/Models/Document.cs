using System;
using System.Collections.Generic;

namespace SearchEngineRest.Models
{
    public partial class Document
    {
        public Document()
        {
            TermDoc = new HashSet<TermDoc>();
        }

        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime? Timestamp { get; set; }

        public virtual ICollection<TermDoc> TermDoc { get; set; }
    }
}
