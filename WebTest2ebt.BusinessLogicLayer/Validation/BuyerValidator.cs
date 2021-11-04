using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.BusinessLogicLayer.Validation
{
    public class BuyerValidator : IValidator<Buyer>
    {
        public bool Validate(Buyer item)
        {
            return !(string.IsNullOrEmpty(item.FirstName) ||
                     string.IsNullOrEmpty(item.SecondName) ||
                     string.IsNullOrEmpty(item.Address) ||
                     string.IsNullOrEmpty(item.Email) ||
                     string.IsNullOrEmpty(item.PhoneNumber) ||
                     !Regex.Match(item.Email, RegexCollection.EmailRegex).Success ||
                     !Regex.Match(item.PhoneNumber, RegexCollection.PhoneRegex).Success);
        }
    }
}
