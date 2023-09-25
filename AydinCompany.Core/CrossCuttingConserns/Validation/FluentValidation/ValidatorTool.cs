using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Core.Entities;
using FluentValidation;

namespace AydinCompany.Core.CrossCuttingConserns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, IEntity entity)
        {
            string errorMessages = "";
            var result = validator.Validate(entity);
            if (result.Errors.Count > 0)
            {
                errorMessages = "";
                foreach (var error in result.Errors)
                {
                    errorMessages += error.ErrorMessage + " ";
                }
                throw new ValidationException(errorMessages);
            }
        }
    }
}
