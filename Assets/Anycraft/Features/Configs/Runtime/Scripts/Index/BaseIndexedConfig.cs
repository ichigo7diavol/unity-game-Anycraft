using Anycraft.Features.Validation;
using FluentValidation;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Configs.Index
{
    [UsedImplicitly]
    public abstract partial class BaseIndexedConfig
        : BaseSerializedConfig
    {
        public new sealed class Validator
            : AbstractValidator<BaseIndexedConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get<BaseSerializedConfig>());
            }
        }

        [HideInInspector]
        [SerializeField] private int _index;

        public int Index => _index;
    }
}