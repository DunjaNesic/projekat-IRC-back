using Microsoft.EntityFrameworkCore;
using Projekat.IRC.BusinessLogic.Interfaces;
using Projekat.IRC.DataAccessLayer;
using Projekat.IRC.Logging;
using Projekat.IRC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.IRC.BusinessLogic
{
    public class ProstorijaLogic : IProstorijaLogic
    {
        public ILoggger Logger { get; }
        public ModelsContext Context { get; }
        public ProstorijaLogic(ModelsContext mContext, ILoggger loger)
        {
            Logger = loger;
            Context = mContext;
        }
        public async Task<List<Prostorija>> GetAllProstorijeAsync()
        {
            Logger.LogInformation($"Called: {nameof(GetAllProstorijeAsync)} from ProstorijaLogic");
            try
            {
                return await Context.Prostorija.ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in {nameof(GetAllProstorijeAsync)}: {ex.Message}");
                throw;
            }
        }

        public async Task<Prostorija> GetProstorijaByNazivSale(string nazivSale)
        {
            Logger.LogInformation($"Called: {nameof(GetProstorijaByNazivSale)} with naziv sale: {nazivSale} from ProstorijaLogic");
            try
            {
                return await Context.Prostorija.FirstOrDefaultAsync(x => x.OznakaSale.ToLower() == nazivSale.ToLower()) ?? throw new Exception("Prostorija not found");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in {nameof(GetProstorijaByNazivSale
                    )}: {ex.Message}");
                throw;
            }
        }
    }
}
