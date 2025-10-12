using UnityEngine;

namespace Anycraft.Frame.Configs.Index
{   
    public abstract partial class BaseIndexedConfig : BaseSerializedConfig
    {
        [HideInInspector]
        [SerializeField] private int _index;

        public int Index => _index;
    }
}