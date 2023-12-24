using Projekat.IRC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.IRC.BusinessLogic.Interfaces
{
    public interface ITipOpremeLogic
    {
        Task<List<TipOpreme>> GetAllTipoviOpremeAsync();

    }
}
