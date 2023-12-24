using Projekat.IRC.Models;

namespace Projekat.IRC.BusinessLogic.Interfaces
{
    public interface IOpremaLogic
    {
        Task<List<Oprema>> GetAllOpremaAsync();
        Task<Oprema> GetOpremaBySerijskiBroj(string serijskiBroj);
        Task AddOpremaAsync(Oprema oprema);
        Task DeleteOpremaAsync(string serijskiBroj);
        Task UpdateOpremaAsync(Oprema oprema, string serijskiBroj);
    }
}