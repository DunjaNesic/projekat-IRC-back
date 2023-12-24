using Microsoft.AspNetCore.Mvc;
using Projekat.IRC.API.Mappers;
using Projekat.IRC.BusinessLogic;
using Projekat.IRC.BusinessLogic.Interfaces;
using Projekat.IRC.DataTransferModel.Oprema;
using Projekat.IRC.Logging;
using Projekat.IRC.Models;

namespace Projekat.IRC.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProstorijaController : ControllerBase
    {
        public IProstorijaLogic ProstorijaLogic { get; }
        private readonly ILoggger loggger;
        public ProstorijaController(ILoggger loger, IProstorijaLogic pLogic)
        {
            loggger = loger;
            ProstorijaLogic = pLogic;
        }

        [HttpGet]
        public async Task<List<Prostorija>> GetProstorija()
        {
            loggger.LogInformation($"Called {nameof(GetProstorija)} from ProstorijaController");
            var prostorija = await ProstorijaLogic.GetAllProstorijeAsync();
            return prostorija.ToList();
        }

        [HttpGet("{nazivSale}")]
        public async Task<Prostorija> Get(string nazivSale)
        {
            loggger.LogInformation($"Called {nameof(Get)} from ProstorijaController");
            var prostorija = await ProstorijaLogic.GetProstorijaByNazivSale(nazivSale);
            return prostorija;
        }



    }
}
