using UnityEngine;
using System;
using System.Collections.Generic;

namespace Anycraft.Frame.Configs.Table
{
    [Serializable]
    public abstract partial class BaseTableEntries<TTable, TConfig>
        where TTable : BaseTableConfig<TConfig>
        where TConfig : BaseSerializedConfig
    {
        [HideInInspector]
        [SerializeField] private List<string> _ids;
        
        public IReadOnlyList<string> Ids => _ids;
    }
}