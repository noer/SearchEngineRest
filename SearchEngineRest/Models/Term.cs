using System;
using System.Collections.Generic;

namespace SearchEngineRest.Models
{
    public partial class Term
    {
        public Term()
        {
            TermDoc = new HashSet<TermDoc>();
        }

        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<TermDoc> TermDoc { get; set; }
    }
}
