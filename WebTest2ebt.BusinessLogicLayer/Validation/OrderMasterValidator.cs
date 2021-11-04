using System;
using System.Collections.Generic;
using System.Text;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.BusinessLogicLayer.Validation
{
    public class OrderMasterValidator : IValidator<OrderMaster>
    {
        public bool Validate(OrderMaster item)
        {
            return !(item.MasterId == null); //Deb
        }
    }
}
