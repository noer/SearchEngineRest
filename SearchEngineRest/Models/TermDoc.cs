using System;
using System.Collections.Generic;

namespace SearchEngineRest.Models
{
    public partial class TermDoc
    {
        public int Docid { get; set; }
        public int Termid { get; set; }
        public int Position { get; set; }

        public virtual Document Doc { get; set; }
        public virtual Term Term { get; set; }
    }
}
