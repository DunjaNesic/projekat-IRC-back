using Microsoft.AspNetCore.Mvc;
using Projekat.IRC.BusinessLogic;
using Projekat.IRC.BusinessLogic.Interfaces;
using Projekat.IRC.DataTransferModel.Oprema;
using Projekat.IRC.DataTransferModel.Zaduzenje;
using Projekat.IRC.Logging;
using Projekat.IRC.Models;
using Projekat.IRC.API.Mappers;


namespace Projekat.IRC.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZaduzenjeController : Controller
    {
        public IZaduzenjeLogic ZaduzenjeLogic { get; }
        private readonly ILoggger loggger;
        public ZaduzenjeController(ILoggger loger, IZaduzenjeLogic zdLogic)
        {
            loggger = loger;
            ZaduzenjeLogic = zdLogic;
        }

        [HttpGet]
        public async Task<List<GetZaduzenjeDTO>> GetZaduzenja()
        {
            loggger.LogInformation($"Called {nameof(GetZaduzenja)} from ZaduzenjaController");
            var zaduzenja = await ZaduzenjeLogic.GetAllZaduzenjaAsync();
            return zaduzenja.Select(ZaduzenjeMapper.ToDto).ToList();
        }

        [HttpPost]
        public async Task Post([FromBody] CreateZaduzenjeDTO createZaduzenjeDTO)
        {
            loggger.LogInformation($"Called {nameof(Post)} from ZaduzenjeController");
            await ZaduzenjeLogic.AddZaduzenjeAsync(createZaduzenjeDTO.FromDto());
        }

        [HttpDelete("{serijskiBrojOpreme}/{DatumZaduzivanja}/{zaposleniID}")]
        public async Task Delete(string serijskiBrojOpreme, DateTime DatumZaduzivanja, int zaposleniID)
        {
            loggger.LogInformation($"Called {nameof(Delete)} from ZaduzenjeController");
            await ZaduzenjeLogic.DeleteZaduzenjeAsync(serijskiBrojOpreme, DatumZaduzivanja, zaposleniID);
        }

    }
}
