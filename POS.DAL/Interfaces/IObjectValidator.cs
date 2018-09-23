using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.DAL.Interfaces
{
    public interface IObjectValidator<T>
        where T : class
    {
        ICollection<ValidationResult> ValidateObject(T model);
    }
}
