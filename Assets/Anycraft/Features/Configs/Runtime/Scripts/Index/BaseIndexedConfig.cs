using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Configs.Index
{
    [UsedImplicitly]
    public abstract partial class BaseIndexedConfig
        : BaseIdentifiableConfig
    {
        [HideInInspector]
        [SerializeField] private int _index;

        public int Index => _index;
    }
}