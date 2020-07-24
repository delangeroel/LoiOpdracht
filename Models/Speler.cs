using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LoiOpdracht.Models
{
    public class Speler : Sporter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpelerId { get; set; }
        [Required]
        public string Straatnaam { get; set; }
        [Required]
        public string Woonplaats { get; set; }
        public Boolean Aktief { get; set; }
        public Speler() { }
        public Speler(string naam)
        {
            this.Naam = naam;
            this.Straatnaam = "";
            this.Woonplaats = "";
            this.Aktief = false;
        }
    }
}
