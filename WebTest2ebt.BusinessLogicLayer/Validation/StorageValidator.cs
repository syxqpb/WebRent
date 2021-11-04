using System;
using System.Collections.Generic;
using System.Text;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.BusinessLogicLayer.Validation
{
    public class StorageValidator : IValidator<Storage>
    {
        public bool Validate(Storage item)
        {
            return !string.IsNullOrEmpty(item.Name);
        }
    }
}
