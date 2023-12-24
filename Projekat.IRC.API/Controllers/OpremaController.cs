
using Microsoft.AspNetCore.Mvc;
using Projekat.IRC.API.Mappers;
using Projekat.IRC.BusinessLogic.Interfaces;
using Projekat.IRC.DataTransferModel.Oprema;
using Projekat.IRC.Logging;
using Projekat.IRC.Models;

namespace Projekat.IRC.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpremaController : ControllerBase
    {
        public IOpremaLogic OpremaLogic { get; }
        private readonly ILoggger loggger;
        public OpremaController(ILoggger loger, IOpremaLogic oLogic)
        {
            loggger = loger;
            OpremaLogic = oLogic;
        }

        [HttpGet]
        public async Task<List<GetOpremaDTO>> GetOprema()
        {
            loggger.LogInformation($"Called {nameof(GetOprema)} from OpremaController");
            var oprema = await OpremaLogic.GetAllOpremaAsync();

            return oprema.Select(OpremaMapper.ToDto).ToList();
        }

        [HttpGet("{serijskiBroj}")]
        public async Task<GetOpremaDTO?> Get(string serijskiBroj)
        {
            loggger.LogInformation($"Called {nameof(Get)} from OpremaController");
            var oprema = await OpremaLogic.GetOpremaBySerijskiBroj(serijskiBroj);

            return oprema?.ToDto();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOpremaDTO createOpremaDto)
        {
            loggger.LogInformation($"Called {nameof(createOpremaDto)} from OpremaController");

            try
            {
                await OpremaLogic.AddOpremaAsync(createOpremaDto.FromDto());
                return Ok(new { Message = "Oprema added successfully" });
            }
            catch (Exception ex)
            {
                loggger.LogError($"Error in {nameof(Post)}: {ex.Message}");
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }


        [HttpDelete("{serijskiBroj}")]
        public async Task Delete(string serijskiBroj)
        {
            loggger.LogInformation($"Called {nameof(Delete)} from OpremaController");
            await OpremaLogic.DeleteOpremaAsync(serijskiBroj);
        }

        [HttpPut("{serijskiBroj}")]
        public async Task Put(string serijskiBroj, [FromBody] UpdateOpremaDTO updateOpremaDto)
        {
            loggger.LogInformation($"Called {nameof(updateOpremaDto)} from OpremaController");
            await OpremaLogic.UpdateOpremaAsync(updateOpremaDto.FromDto(), serijskiBroj);

        }

    }
}
