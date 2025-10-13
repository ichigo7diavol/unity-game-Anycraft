using FluentValidation;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Configs
{
    [UsedImplicitly]
    public abstract partial class BaseSerializedConfig
        : ScriptableObject, IConfig
    {
        public sealed class Validator
            : AbstractValidator<BaseSerializedConfig>
        {
            public Validator()
            {
                RuleFor(c => c._id)
                    .NotNull()
                    .NotEmpty();
            }
        }

        [HideInInspector]
        [SerializeField] string _id;

        public string Id => _id;

        public abstract void Validate();
    }
}