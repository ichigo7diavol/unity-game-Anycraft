using System;
using System.Collections.Concurrent;
using FluentValidation;
using JetBrains.Annotations;

namespace Anycraft.Features.Validation
{
    [UsedImplicitly]
    public static class ValidatorCache
    {
        private static readonly ConcurrentDictionary<Type, IValidator> _validators = new();

        public static IValidator Get<TValidator>() 
            where TValidator : IValidator, new()
        {
            return (TValidator)_validators
                .GetOrAdd(typeof(TValidator), _ => new TValidator());
        }

        public static IValidator<TValidatable> Get<TValidator, TValidatable>()
            where TValidator : IValidator<TValidatable>, new()
        {
            return (TValidator)_validators
                .GetOrAdd(typeof(TValidator), _ => new TValidator());
        }
    }
}