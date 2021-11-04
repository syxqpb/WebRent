using System;
using System.Collections.Generic;
using System.Text;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.BusinessLogicLayer.Validation
{
    public class FlashBulbValidator : IValidator<FlashBulb>
    {
        public bool Validate(FlashBulb item)
        {
            return !string.IsNullOrEmpty(item.Name);
        }
    }
}
