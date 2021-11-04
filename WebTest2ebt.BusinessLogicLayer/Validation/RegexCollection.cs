using System;
using System.Collections.Generic;
using System.Text;

namespace WebTest2ebt.BusinessLogicLayer.Validation
{
    public static class RegexCollection
    {
        public const string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string PhoneRegex = @"^(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$";
    }
}
