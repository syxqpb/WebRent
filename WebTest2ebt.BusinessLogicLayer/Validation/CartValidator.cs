using System;
using System.Collections.Generic;
using System.Text;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.BusinessLogicLayer.Validation
{
    public class CartValidator : IValidator<Cart>
    {
        public bool Validate(Cart item)
        {
            return true;
        }
    }
}
