using Microsoft.AspNetCore.Mvc;
using Projekat.IRC.API.Mappers;
using Projekat.IRC.BusinessLogic;
using Projekat.IRC.BusinessLogic.Interfaces;
using Projekat.IRC.DataTransferModel.Oprema;
using Projekat.IRC.DataTransferModel.TipOpreme;
using Projekat.IRC.Logging;

namespace Projekat.IRC.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipOpremeController : Controller
    {
        public ITipOpremeLogic TipOpremeLogic { get; }
        private readonly ILoggger loggger;
        public TipOpremeController(ILoggger loger, ITipOpremeLogic tOLogic)
        {
            loggger = loger;
            TipOpremeLogic = tOLogic;
        }

        [HttpGet]
        public async Task<List<GetTipOpremeDTO>> GetTipOpreme()
        {
            loggger.LogInformation($"Called {nameof(GetTipOpreme)} from TipOpremeController");
            var tipOpreme = await TipOpremeLogic.GetAllTipoviOpremeAsync();

            return tipOpreme.Select(TipOpremeMapper.ToDto).ToList();
        }
    }
}
