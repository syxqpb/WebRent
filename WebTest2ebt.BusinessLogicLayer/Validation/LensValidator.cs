using System;
using System.Collections.Generic;
using System.Text;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.BusinessLogicLayer.Validation
{
    public class LensValidator : IValidator<Lens>
    {
        public bool Validate(Lens item)
        {
            return !string.IsNullOrEmpty(item.Name);
        }
    }
}
