using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.IRC.Models
{
    public enum Status
    {
        Raspolozivo = 1,
        Zauzeto,
        Kvar
    }
    public class Oprema
    {
        [Key]
        public string SerijskiBrojOpreme { get; set; }
        public string InventarskiBroj { get; set; }
        public string Naziv { get; set; }
        [MaxLength(42)]
        public string? Specs { get; set; }
        public TipOpreme TipOpreme { get; set; }
        public int TipOpremeID { get; set; }
        public string ProstorijaOznakaSale { get; set; }
        public Prostorija? Prostorija { get; set; }
        public List<Zaduzenje>? Zaduzenja { get; set; }
        public Status Status { get; set; } = Status.Raspolozivo;
        public byte[] RowVersion { get; set; }
    }
}