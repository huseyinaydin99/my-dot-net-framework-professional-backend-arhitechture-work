using AydinCompany.Core.Entities;
using FluentValidation;

namespace AydinCompany.Core.CrossCuttingConcerns.Validation.FluentValidation
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
