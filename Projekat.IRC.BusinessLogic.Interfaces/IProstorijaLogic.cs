using Projekat.IRC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.IRC.BusinessLogic.Interfaces
{
    public interface IProstorijaLogic
    {
        Task<List<Prostorija>> GetAllProstorijeAsync();
        Task<Prostorija> GetProstorijaByNazivSale(string nazivSale);
    }
}
