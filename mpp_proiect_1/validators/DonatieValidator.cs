using mpp_proiect_1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.validators
{
    public class DonatieValidator : IValidator<Donatie>
    {
        public void validate(Donatie elem)
        {
            StringBuilder errorString = new StringBuilder();
            if (elem.Id < 0)
                errorString.Append("Id-ul trebuie sa fie un numar pozitiv!");
            if (elem.IdD < 0)
                errorString.Append("Id-ul Donatorului trebuie sa fie un numar pozitiv!");
            if (elem.IdC <0 )
                errorString.Append("Id-ul Cazului trebuie sa fie un numar pozitiv!");
            if (elem.Suma < 0)
                errorString.Append("Suma donata trebuie sa fie un numar pozitiv!");


            if (errorString.Length != 0)
                throw new ValidationException(errorString.ToString());
        }
    }
}
