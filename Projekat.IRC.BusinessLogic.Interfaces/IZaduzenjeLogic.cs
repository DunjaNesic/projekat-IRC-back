using Projekat.IRC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.IRC.BusinessLogic.Interfaces
{
    public interface IZaduzenjeLogic
    {
        Task<List<Zaduzenje>> GetAllZaduzenjaAsync();
        Task AddZaduzenjeAsync(Zaduzenje zaduzenje);
        Task DeleteZaduzenjeAsync(string serijskiBrojOpreme, DateTime DatumZaduzivanja, int zaposleniID);
    }
}
