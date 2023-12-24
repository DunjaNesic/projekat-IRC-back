using Projekat.IRC.DataTransferModel.Oprema;
using Projekat.IRC.Models;

namespace Projekat.IRC.API.Mappers
{
    public static class OpremaMapper
    {
        public static GetOpremaDTO ToDto(this Oprema oprema) => new()
        {
            SerijskiBrojOpreme = oprema.SerijskiBrojOpreme,
            InventarskiBroj = oprema.InventarskiBroj,
            Naziv = oprema.Naziv,
            Specs = oprema.Specs,
            TipOpremeID = oprema.TipOpremeID,
            RowVersion = oprema.RowVersion,
            ProstorijaOznakaSale = oprema.ProstorijaOznakaSale,
            Status = (int)oprema.Status
        };

        public static Oprema FromDto(this CreateOpremaDTO dto) => new() {
        SerijskiBrojOpreme = dto.SerijskiBrojOpreme,
        InventarskiBroj = dto.InventarskiBroj,
        Naziv = dto.Naziv,
        Specs = dto.Specs,
        TipOpremeID = dto.TipOpremeID,
        ProstorijaOznakaSale = dto.ProstorijaOznakaSale
        };

        public static Oprema FromDto(this UpdateOpremaDTO dto) => new()
        {
            Status = (Status)dto.Status,
            RowVersion = dto.RowVersion
           
        };

    
    }
}
