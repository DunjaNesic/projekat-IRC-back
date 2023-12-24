using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.IRC.DataTransferModel.Zaduzenje
{
    public class CreateZaduzenjeDTO
    {
        public DateTime DatumZaduzivanja { get; set; } = new DateTime();
        public int ZaposleniID { get; set; }
        public string SerijskiBrojOpreme { get; set; }
    }
}
