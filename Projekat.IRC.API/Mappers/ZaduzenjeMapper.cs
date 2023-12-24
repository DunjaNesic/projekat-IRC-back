using Projekat.IRC.DataTransferModel.Oprema;
using Projekat.IRC.DataTransferModel.Zaduzenje;
using Projekat.IRC.Models;

namespace Projekat.IRC.API.Mappers
{
    public static class ZaduzenjeMapper
    {
        public static GetZaduzenjeDTO ToDto(this Zaduzenje zaduzenje) => new()
        {
            DatumZaduzivanja = zaduzenje.DatumZaduzivanja,
            SerijskiBrojOpreme = zaduzenje.SerijskiBrojOpreme,
            ZaposleniID = zaduzenje.ZaposleniID
        };
        public static Zaduzenje FromDto(this CreateZaduzenjeDTO dto) => new()
        {
            DatumZaduzivanja = dto.DatumZaduzivanja,
            SerijskiBrojOpreme = dto.SerijskiBrojOpreme,
            ZaposleniID = dto.ZaposleniID,
        };

    }
}
