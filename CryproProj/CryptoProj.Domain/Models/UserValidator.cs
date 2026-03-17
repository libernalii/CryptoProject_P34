using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CryptoProj.Domain.Models
{
    public class UserValidator
    {
        public bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            return Regex.IsMatch(name, @"^[a-zA-Z0-9_]+$");
        }

        public bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 8)
                return false;

            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower))
                return false;

            string specialChars = "!;%@*";
            if (!password.Any(c => specialChars.Contains(c)))
                return false;

            string zodiacSigns = "♈♉♊♋♌♍♎♏♐♑♒♓";
            if (!password.Any(c => zodiacSigns.Contains(c)))
                return false;

            string romanChars = "IVXLCDM";
            if (!password.Any(c => romanChars.Contains(c)))
                return false;

            return true;
        }
    }
}
