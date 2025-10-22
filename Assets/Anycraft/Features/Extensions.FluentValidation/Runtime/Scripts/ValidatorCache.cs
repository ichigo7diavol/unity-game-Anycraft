using System;
using System.Collections.Concurrent;
using FluentValidation;
using JetBrains.Annotations;

namespace Anycraft.Features.Extensions.FluentValidation
{
    [UsedImplicitly]
    public static class ValidatorCache
    {
        private static readonly ConcurrentDictionary<Type, IValidator> _validators = new();

        public static IValidator<TValidatable> Get<TValidator, TValidatable>()
            where TValidator : IValidator<TValidatable>, new()
        {
            return (IValidator<TValidatable>)_validators
                .GetOrAdd
                (
                    typeof(TValidator),
                    _ => new TValidator()
                );
        }
    }
}