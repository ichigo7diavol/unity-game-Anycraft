using UnityEngine;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Anycraft.Features.Configs.Table
{
    [Serializable]
    [UsedImplicitly]
    public abstract partial class BaseTableEntries<TTable, TConfig> 
        where TTable : BaseTableConfig<TConfig>
        where TConfig : BaseIdentifiableConfig
    {
        [HideInInspector]
        [SerializeField] private List<string> _ids;

        public IReadOnlyList<string> Ids => _ids;
    }
}