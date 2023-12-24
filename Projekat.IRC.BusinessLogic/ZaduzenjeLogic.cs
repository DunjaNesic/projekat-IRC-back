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
    public class ZaduzenjeLogic : IZaduzenjeLogic
    {
        public ILoggger Logger { get; }
        public ModelsContext Context { get; }
        public ZaduzenjeLogic(ModelsContext mContext, ILoggger loger)
        {
            Logger = loger;
            Context = mContext;
        }
        public async Task AddZaduzenjeAsync(Zaduzenje zaduzenje)
        {
            Logger.LogInformation($"Called: {nameof(AddZaduzenjeAsync)} from ZaduzenjeLogic");
            try
            {
                Context.Zaduzenje.Add(zaduzenje);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in {nameof(AddZaduzenjeAsync)}: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteZaduzenjeAsync(string serijskiBrojOpreme, DateTime DatumZaduzivanja, int zaposleniID)
        {
            Logger.LogInformation($"Called: {nameof(DeleteZaduzenjeAsync)} from ZaduzenjeLogic");
            try
            {
                var existingZaduzenje = await Context.Zaduzenje.FirstOrDefaultAsync(x => x.SerijskiBrojOpreme.ToLower() == serijskiBrojOpreme.ToLower() && x.DatumZaduzivanja == DatumZaduzivanja && x.ZaposleniID == zaposleniID);

                if (existingZaduzenje == null)
                    return;

                Context.Zaduzenje.Remove(existingZaduzenje);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in {nameof(DeleteZaduzenjeAsync)}: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Zaduzenje>> GetAllZaduzenjaAsync()
        {
            Logger.LogInformation($"Called: {nameof(GetAllZaduzenjaAsync)} from ZaduzenjeLogic");
            try
            {
                return await Context.Zaduzenje.ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in {nameof(GetAllZaduzenjaAsync)}: {ex.Message}");
                throw;
            }
        }
    }
}
