using System;
using System.Collections.Generic;

namespace BusinessModel.Core.Models
{
    public partial class roysched
    {
        public string title_id { get; set; }
        public Nullable<int> lorange { get; set; }
        public Nullable<int> hirange { get; set; }
        public Nullable<int> royalty { get; set; }
        public virtual title title { get; set; }
    }
}
