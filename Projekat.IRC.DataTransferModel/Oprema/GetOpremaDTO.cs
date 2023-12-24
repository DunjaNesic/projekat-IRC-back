using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.IRC.DataTransferModel.Oprema
{
    public class GetOpremaDTO
    {
        public string SerijskiBrojOpreme { get; set; }
        public string InventarskiBroj { get; set; }
        public string Naziv { get; set; }
        public int TipOpremeID { get; set; }
        public string? Specs { get; set; }
        public byte[] RowVersion { get; set; }
        public string ProstorijaOznakaSale { get; set; }
        public int Status { get; set; }


    }
}
