using System;
using System.Collections.Generic;
using System.Text;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.BusinessLogicLayer.Validation
{
    public class MicrophoneValidator : IValidator<Microphone>
    {
        public bool Validate(Microphone item)
        {
            return !string.IsNullOrEmpty(item.Name);
        }
    }
}
