using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.IRC.Models
{
    public class Prostorija
    {
        [Key]
        public string OznakaSale { get; set; }
        public string Sprat { get; set; }
        public int Kapacitet { get; set; }
        public List<Oprema>? Oprema { get; set; }
        public override string ToString()
        {
            return OznakaSale;

        }
    }
}
