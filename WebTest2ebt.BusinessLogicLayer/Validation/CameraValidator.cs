using System;
using System.Collections.Generic;
using System.Text;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.BusinessLogicLayer.Validation
{
    public class CameraValidator : IValidator<Camera>
    {
        public bool Validate(Camera item)
        {
            return !string.IsNullOrEmpty(item.Name);
        }
    }
}
