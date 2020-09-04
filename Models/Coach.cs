using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoiOpdracht.Models
{
    public class Coach : Sporter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoachId { get; set; }
         
        public string Voornaam { get; set; }
        public Boolean Active { get; set; }
        public Coach() { }
        public Coach(int CoachId, string Naam) { this.CoachId = CoachId; this.Naam = Naam; }
        public Coach(string Naam, string Voornaam, Boolean Active) { this.Naam = Naam; this.Voornaam = Voornaam; this.Active = Active; }
        public Coach(string Naam) { this.Naam = Naam; this.Voornaam = ""; this.Active = false; }
        public string toString()
        {
            return Naam;
        }
    }
}
