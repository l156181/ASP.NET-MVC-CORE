using System;
using System.Collections.Generic;

namespace entity_frawework_core_1.Model
{
    public partial class Film
    {
        public Film()
        {
            FilmActor = new HashSet<FilmActor>();
            FilmCategory = new HashSet<FilmCategory>();
        }

        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseYear { get; set; }
        public byte LanguageId { get; set; }
        public byte? OriginalLanguageId { get; set; }
        public short? Length { get; set; }
        public string Rating { get; set; }
        public DateTime LastUpdate { get; set; }

        public Language Language { get; set; }
        public Language OriginalLanguage { get; set; }
        public ICollection<FilmActor> FilmActor { get; set; }
        public ICollection<FilmCategory> FilmCategory { get; set; }
    }
}
