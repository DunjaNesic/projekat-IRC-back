using Projekat.IRC.DataTransferModel.Oprema;
using Projekat.IRC.DataTransferModel.TipOpreme;
using Projekat.IRC.Models;

namespace Projekat.IRC.API.Mappers
{
    public static class TipOpremeMapper
    {
        public static GetTipOpremeDTO ToDto(this TipOpreme tipOpreme) => new()
        {
            NazivTipaOpreme = tipOpreme.Naziv,
            TipOpremeID = tipOpreme.TipOpremeID

        };
    }
}
