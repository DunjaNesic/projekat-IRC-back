using Microsoft.EntityFrameworkCore;
using Projekat.IRC.BusinessLogic.Interfaces;
using Projekat.IRC.BusinessLogic.Validators;
using Projekat.IRC.DataAccessLayer;
using Projekat.IRC.Logging;
using Projekat.IRC.Models;

namespace Projekat.IRC.BusinessLogic
{
    public class OpremaLogic : IOpremaLogic
    {
        public ILoggger Logger { get;}
        public ModelsContext Context { get;}
        public OpremaLogic(ModelsContext mContext, ILoggger loger)
        {
            Logger = loger;
            Context = mContext;
        }

        public async Task<List<Oprema>> GetAllOpremaAsync()
        {
            Logger.LogInformation($"Called: {nameof(GetAllOpremaAsync)} from OpremaLogic");
            try
            {
                return await Context.Oprema.ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in {nameof(GetAllOpremaAsync)}: {ex.Message}");
                throw;
            }
        }
        public async Task<Oprema> GetOpremaBySerijskiBroj(string serijskiBroj)
        {
            Logger.LogInformation($"Called: {nameof(GetOpremaBySerijskiBroj)} with serijskiBroj: {serijskiBroj} from OpremaLogic");
            try
            {
                return await Context.Oprema.FirstOrDefaultAsync(x => x.SerijskiBrojOpreme.ToLower() == serijskiBroj.ToLower()) ?? throw new Exception("Oprema not found");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in {nameof(GetOpremaBySerijskiBroj)}: {ex.Message}");
                throw;
            }
        }
        public async Task AddOpremaAsync(Oprema oprema)
        {
            Logger.LogInformation($"Called: {nameof(AddOpremaAsync)} from OpremaLogic");
            try
            {
                OpremaValidator validator = new OpremaValidator();
                var errorMessages = validator.Validate(oprema);

                if (errorMessages.Count != 0)
                {
                    foreach (var message in errorMessages)
                    {
                        Console.WriteLine(message);
                    }
                    return;
                }
                Context.Oprema.Add(oprema);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in {nameof(AddOpremaAsync)}: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteOpremaAsync(string serijskiBroj)
        {
            Logger.LogInformation($"Called: {nameof(DeleteOpremaAsync)} from OpremaLogic");
            try
            {
                var existingOprema = await Context.Oprema.FirstOrDefaultAsync(x => x.SerijskiBrojOpreme.ToLower() == serijskiBroj.ToLower());

                if (existingOprema == null)
                    return;

                Context.Oprema.Remove(existingOprema);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in {nameof(DeleteOpremaAsync)}: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateOpremaAsync(Oprema oprema, string serijskiBroj)
        {
            Logger.LogInformation($"Called: {nameof(UpdateOpremaAsync)} from OpremaLogic");
            var existingOprema = await Context.Oprema.FirstOrDefaultAsync(x => x.SerijskiBrojOpreme.ToLower() == serijskiBroj.ToLower());

            if (existingOprema == null)
                return;

            if (existingOprema.RowVersion.SequenceEqual(oprema.RowVersion) == false)
            {
                throw new DbUpdateConcurrencyException("Radite sa zastarelim podacima o opremi");
            }

            existingOprema.RowVersion = oprema.RowVersion;
            existingOprema.Status = oprema.Status;
          

            await Context.SaveChangesAsync();
        }
    }
}