using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.validators
{
    public interface IValidator<T>
    {
        void validate(T elem);
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message)
        : base(message) { }
    }
}
