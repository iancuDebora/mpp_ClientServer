using mpp_proiect_1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.validators
{
    public class DonatorValidator : IValidator<Donator>
    {
        public void validate(Donator elem)
        {
            StringBuilder errorString = new StringBuilder();
            if (elem.Id < 0)
                errorString.Append("Id-ul trebuie sa fie un numar pozitiv!");
            if (elem.Nume == "")
                errorString.Append("Numele nu poate fi vid!");
            if (elem.Adresa == "")
                errorString.Append("Adresa nu poate fi vida!");
            if (elem.NrTelefon < 0)
                errorString.Append("Nr de telefon trebuie sa fie un numar pozitiv!");
            

            if (errorString.Length != 0)
                throw new ValidationException(errorString.ToString());
        }
    }
}