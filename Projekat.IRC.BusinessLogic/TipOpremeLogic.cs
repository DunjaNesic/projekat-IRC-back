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
    public class TipOpremeLogic : ITipOpremeLogic
    {
        public ILoggger Logger { get; }
        public ModelsContext Context { get; }
        public TipOpremeLogic(ModelsContext mContext, ILoggger loger)
        {
            Logger = loger;
            Context = mContext;
        }

        public async Task<List<TipOpreme>> GetAllTipoviOpremeAsync()
        {

            Logger.LogInformation($"Called: {nameof(GetAllTipoviOpremeAsync)} from TipOpremeLogic");
            try
            {
                return await Context.TipOpreme.ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in {nameof(GetAllTipoviOpremeAsync)}: {ex.Message}");
                throw;
            }
        }
    }
}
