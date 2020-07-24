using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;

namespace LoiOpdracht.Models
{
    public class Team : Sporter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        public string TeamNaam { get; set; }

        [MaxLength(30)]
        public string SoortSport { get; set; }

        [ForeignKey("Coach")]
        public int? CoachId { get; set; }
        public virtual Coach Coach { get; set; }


        [ForeignKey("Speler1FK")]
        public int? SpelerId { get; set; }
        public virtual Speler Speler1 { get; set; }

        [ForeignKey("Speler2FK"), Editable(false), ReadOnly(true)]
        public int? Speler2Id { get; set; }
        public virtual Speler Speler2 { get; set; }


        public Team()
        {
        }
        public Team(string teamnaam)
        {
            this.TeamNaam = teamnaam;
            SoortSport = "";

        }
    }
}
