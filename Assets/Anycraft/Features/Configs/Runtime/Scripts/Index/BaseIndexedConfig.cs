using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Configs.Index
{
    [UsedImplicitly]
    public abstract partial class BaseIndexedConfig
        : BaseSerializedConfig
    {
        [HideInInspector]
        [SerializeField] private int _index;

        public int Index => _index;
    }
}