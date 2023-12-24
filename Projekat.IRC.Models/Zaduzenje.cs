using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Projekat.IRC.Models
{
    public class Zaduzenje
    {
        [Key]
        public DateTime DatumZaduzivanja { get; set; } 
        public int ZaposleniID { get; set; }
        public string SerijskiBrojOpreme { get; set; }
        public Zaposleni Zaposleni { get; set; }
        public Oprema Oprema { get; set; }
        public override string ToString()
        {
            return $"{DatumZaduzivanja},{ZaposleniID},{SerijskiBrojOpreme}";
        }
    }
}
