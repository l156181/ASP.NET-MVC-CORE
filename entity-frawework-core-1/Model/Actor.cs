using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace entity_frawework_core_1.Model
{
//  [Table("actor")]
    public partial class Actor
    {
        public Actor()
        {
            FilmActor = new HashSet<FilmActor>();
        }
        
//      [Column("actor_id")]      
        public int ActorId { get; set; }

//        [Required]
//      [Column("first_name", "varchar(45)")]
//      [Column("first_name", TypeName="varchar(45)")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastUpdate { get; set; }

        public ICollection<FilmActor> FilmActor { get; set; }

        public override string ToString(){
            return "ACTOR "+ this.ActorId +  "".PadRight(19) + this.FirstName.PadRight(20) + this.LastName;
        }
    }
}
