using POS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Validation.ObjectPropValidation
{
    class ObjectValidator<T> : IObjectValidator<T> 
        where T : class
    {
        public virtual ICollection<ValidationResult> ValidateObject(T model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            Validator.TryValidateObject(model, context, validationResults, true);
            return validationResults;
        }
    }
}
