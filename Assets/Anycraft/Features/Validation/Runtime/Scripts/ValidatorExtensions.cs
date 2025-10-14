using System;
using FluentValidation;
using FluentValidation.Results;

namespace Anycraft.Features.Validation
{
    public static class ValidatorExtensions
    {
        public static ValidationResult ValidateDynamic(this IValidator validator, object instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var instanceType = instance.GetType();
            var contextType = typeof(ValidationContext<>).MakeGenericType(instanceType);
            var context = Activator.CreateInstance(contextType, instance);

            var validateMethod = validator.GetType().GetMethod("Validate", new[] { contextType });
            if (validateMethod == null)
                throw new InvalidOperationException($"Validator {validator.GetType().Name} does not support type {instanceType.Name}");

            return (ValidationResult)validateMethod.Invoke(validator, new[] { context });
        }
    }
}