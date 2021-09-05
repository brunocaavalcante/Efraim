using FluentValidation;
using FluentValidation.Results;

namespace Business.Core.Validations
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        public BaseValidator()
        {
            
        }

        protected override bool PreValidate(ValidationContext<T> context, ValidationResult result) 
        {
            if (context.InstanceToValidate == null) 
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));
                return false;
            }
            return true;
        }
    }
}