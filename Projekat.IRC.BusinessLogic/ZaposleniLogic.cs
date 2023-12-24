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
    public class ZaposleniLogic : IZaposleniLogic
    {
        public ILoggger Logger { get; }
        public ModelsContext Context { get; }
        public ZaposleniLogic(ModelsContext mContext, ILoggger loger)
        {
            Logger = loger;
            Context = mContext;
        }
        public async Task<List<Zaposleni>> GetAllZaposleniAsync()
        {
            Logger.LogInformation($"Called: {nameof(GetAllZaposleniAsync)} from ZaposleniLogic");
            try
            {
                return await Context.Zaposleni.ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in {nameof(GetAllZaposleniAsync)}: {ex.Message}");
                throw;
            }
        }

        public async Task<Zaposleni> GetZaposleniByZaposleniID(int zaposleniID)
        {
            Logger.LogInformation($"Called: {nameof(GetAllZaposleniAsync)} with zaposleniID: {zaposleniID} from ZaposleniLogic");
            try
            {
                return await Context.Zaposleni.FirstOrDefaultAsync(x => x.ZaposleniID == zaposleniID) ?? throw new Exception("Oprema not found");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in {nameof(GetZaposleniByZaposleniID)}: {ex.Message}");
                throw;
            }
        }
    }
}
