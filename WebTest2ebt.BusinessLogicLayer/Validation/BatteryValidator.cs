using System;
using System.Collections.Generic;
using System.Text;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.BusinessLogicLayer.Validation
{
    public class BatteryValidator : IValidator<Battery>
    {
        public bool Validate(Battery item)
        {
            return !string.IsNullOrEmpty(item.Name);
        }
    }
}
