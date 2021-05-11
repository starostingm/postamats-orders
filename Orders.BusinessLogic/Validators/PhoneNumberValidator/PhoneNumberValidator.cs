using Orders.BusinessLogic.Validators.PhoneNumberValidator.Interfaces;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Orders.BusinessLogic.Validators.PhoneNumberValidator
{
    public class PhoneNumberValidator : IPhoneNumberValidator
    {
        private readonly string PhoneNumberRegexPattern;

        public PhoneNumberValidator()
        {
            var mask = "+7XXX-XXX-XX-XX";

            var validMaskChars = new[] { '+', '7', 'X', '-' };
            var isMaskInvalid = mask.Any(x => !validMaskChars.Contains(x));
            if (isMaskInvalid)
            {
                throw new Exception("Invalid phone number mask.");
            }

            PhoneNumberRegexPattern = 
                "^" + 
                mask.Replace("+", @"\+")
                    .Replace("X", @"\d")
                    .Replace("-", @"\-")
                + "$";
        }

        public bool IsValid(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, PhoneNumberRegexPattern);
        }
    }
}
