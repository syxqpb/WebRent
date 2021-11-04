using System;
using System.Collections.Generic;
using System.Text;

namespace WebTest2ebt.BusinessLogicLayer.Validation
{
    public interface IValidator<T> where T : class
    {
        bool Validate(T item);
    }
}
