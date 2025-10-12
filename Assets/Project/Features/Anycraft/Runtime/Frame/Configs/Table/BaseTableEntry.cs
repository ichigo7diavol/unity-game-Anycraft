using UnityEngine;
using System;

namespace Anycraft.Frame.Configs.Table
{
    [Serializable]
    public abstract partial class BaseTableEntry<TTable, TConfig>
        where TTable : BaseTableConfig<TConfig>
        where TConfig : BaseSerializedConfig
    {
        [HideInInspector]
        [SerializeField] private string _id;

        public string Id => _id;
    }
}