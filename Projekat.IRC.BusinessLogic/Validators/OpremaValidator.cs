using Projekat.IRC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projekat.IRC.BusinessLogic.Validators
{
    public class OpremaValidator
    {
        public List<string> Validate(Oprema oprema)
        {
            if (oprema == null)
                throw new ArgumentNullException(nameof(oprema));

            var errorMessages = new List<string>();

            errorMessages.AddRange(ValidateField(oprema.SerijskiBrojOpreme, "Serijski broj", ValidateSerijskiBroj));
            errorMessages.AddRange(ValidateField(oprema.InventarskiBroj, "Inventarski broj", ValidateInventarskiBroj));
            errorMessages.AddRange(ValidateField(oprema.Naziv, "Naziv", ValidateName));
            errorMessages.AddRange(ValidateField(oprema.Specs, "Specs", ValidateSpecs));
            errorMessages.AddRange(ValidateField(oprema.ProstorijaOznakaSale, "Prostorija", ValidateProstorija));


            return errorMessages;
        }
        private List<string> ValidateField(string? fieldValue, string fieldName, Func<string, string?> validationFunc)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(fieldValue))
            {
                errors.Add($"Morate proslediti vrednost za {fieldName}");
            }
            else
            {
                var validationMessage = validationFunc(fieldValue);
                if (validationMessage != null)
                {
                    errors.Add(validationMessage);
                }
            }
            return errors;
        }

        private string? ValidateProstorija(string? prostorija)
        {
            if (string.IsNullOrWhiteSpace(prostorija))
                return "Morate proslediti vrednost za naziv opreme";
            else return null;
        }
            private string? ValidateName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Morate proslediti vrednost za naziv opreme";

            Regex regex = new Regex(@"^[a-zA-Z\s]+$");


            if (regex.IsMatch(name) == false)
                return "Naziv opreme mora biti napisan iskljucivo slovima, bez brojeva";

            return null;
        }

        private string? ValidateSerijskiBroj(string serijskiBroj)
        {
            if (string.IsNullOrWhiteSpace(serijskiBroj))
                return "Morate proslediti vrednost za serijski broj opreme";

            if (!Regex.IsMatch(serijskiBroj, "^[a-zA-Z0-9]+$"))
                return "Serijski broj opreme mora biti od slova i/ili brojeva";

            return null;
        }

        public string? ValidateSpecs(string? specification)
        {
            if (specification?.Length < 4)
            {
                return "Specifications opreme mora imati minimum 4 karaktera";
            }
            return null;
        }

        public string? ValidateInventarskiBroj(string inventarskiBroj)
        {
            if (string.IsNullOrWhiteSpace(inventarskiBroj))
            {
                return "Morate proslediti vrednost za inventarski broj";
            }
            Regex regex = new Regex("^[a-zA-Z0-9]+$");
            if (regex.IsMatch(inventarskiBroj) == false)
            {
                return "Inventarski broj mora biti od slova i/ili brojeva!";
            }
            return null;
        }


    }
}
