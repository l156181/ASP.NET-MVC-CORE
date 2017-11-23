using System;
using System.Collections.Generic;

namespace entity_frawework_core_1.Model
{
    public partial class FilmCategory
    {
        public int FilmId { get; set; }
        public byte CategoryId { get; set; }
        public DateTime LastUpdate { get; set; }

        public Category Category { get; set; }
        public Film Film { get; set; }
    }
}
