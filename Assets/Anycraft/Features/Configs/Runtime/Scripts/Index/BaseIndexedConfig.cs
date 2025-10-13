using UnityEngine;

namespace Anycraft.Features.Configs.Index
{   
    public abstract partial class BaseIndexedConfig : BaseSerializedConfig
    {
        [HideInInspector]
        [SerializeField] private int _index;

        public int Index => _index;
    }
}