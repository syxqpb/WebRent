using System;
using System.Collections.Generic;
using System.Text;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.BusinessLogicLayer.Validation
{
    public class MasterValidator : IValidator<Master>
    {
        public bool Validate(Master item)
        {
            return !(item.OrderMasters == null); //Deb
        }
    }
}
