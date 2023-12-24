using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.IRC.Models
{
    public class Zaposleni
    {
        [Key]
        public int ZaposleniID { get; set; }
        public string ImePrezime { get; set; }
        public string Email { get; set; }
        public string Katedra { get; set; }
        public List<Zaduzenje>? Zaduzenja { get; set; }
        public override string ToString()
        {
            return ImePrezime;
        }
    }
}
