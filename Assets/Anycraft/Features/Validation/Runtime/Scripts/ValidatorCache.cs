using System;
using System.Collections.Concurrent;
using System.Linq;
using FluentValidation;
using JetBrains.Annotations;
using UnityEditor;

namespace Anycraft.Features.Validation
{
    [UsedImplicitly]
    public static class ValidatorCache
    {
        private static readonly ConcurrentDictionary<Type, IValidator> _validators = new();

        public static IValidator Get(Type validatableType)
        {
            return _validators
                .GetOrAdd
                (
                    validatableType,
                    _ => (IValidator)CreateFirstSubclassInstance(GetAbstractValidatorType(validatableType))
                );
        }

        public static IValidator<TValidatable> Get<TValidatable>()
        {
            return (IValidator<TValidatable>)_validators
                .GetOrAdd
                (
                    typeof(TValidatable),
                    _ => (IValidator)CreateFirstSubclassInstance(typeof(AbstractValidator<TValidatable>))
                );
        }

        public static Type GetAbstractValidatorType(Type validatableType)
        {
            if (validatableType == null)
                throw new ArgumentNullException(nameof(validatableType));

            return typeof(AbstractValidator<>).MakeGenericType(validatableType);
        }

        private static Type GetFirstSubclassOf(Type baseType)
        {
            return AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .First(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(baseType));
        }

        private static object CreateFirstSubclassInstance(Type baseType)
        {
            var subclass = GetFirstSubclassOf(baseType);
            if (subclass == null)
                return new InvalidOperationException("Missing subclass");

            var ctor = subclass.GetConstructor(Type.EmptyTypes);
            if (ctor == null)
                throw new MissingMethodException($"Type {subclass.Name} does not have any ctor()");

            return Activator.CreateInstance(subclass);
        }
    }
}