using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.IRC.Models
{
    public class TipOpreme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipOpremeID { get; set; }
        public string Naziv { get; set; }
        public List<Oprema>? Oprema { get; set; }
        public override string ToString()
        {
            return Naziv;
        }
    }
}
