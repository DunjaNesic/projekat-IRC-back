using Microsoft.AspNetCore.Mvc;
using Projekat.IRC.BusinessLogic;
using Projekat.IRC.BusinessLogic.Interfaces;
using Projekat.IRC.Logging;
using Projekat.IRC.Models;

namespace Projekat.IRC.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZaposleniController : Controller
    {
        public IZaposleniLogic ZaposleniLogic { get; }
        private readonly ILoggger loggger;
        public ZaposleniController(ILoggger loger, IZaposleniLogic zLogic)
        {
            loggger = loger;
            ZaposleniLogic = zLogic;
        }

        [HttpGet]
        public async Task<List<Zaposleni>> GetZaposleni()
        {
            loggger.LogInformation($"Called {nameof(GetZaposleni)} from ZaposleniController");
            var zaposleni = await ZaposleniLogic.GetAllZaposleniAsync();
            return zaposleni.ToList();
        }

        [HttpGet("{zaposleniID}")]
        public async Task<Zaposleni> Get(int zaposleniID)
        {
            loggger.LogInformation($"Called {nameof(Get)} from ZaposleniController");
            var zaposleni = await ZaposleniLogic.GetZaposleniByZaposleniID(zaposleniID);
            return zaposleni;
        }



    }
}
