using System;
using System.Collections.Generic;
using System.Text;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.BusinessLogicLayer.Validation;

namespace WebTest2ebt.BusinessLogicLayer.Managers
{
    public class EquipmentValidator : IValidator<Equipment>
    {
        public bool Validate(Equipment item)
        {
            return !string.IsNullOrEmpty(item.Name);
        }
    }
}
