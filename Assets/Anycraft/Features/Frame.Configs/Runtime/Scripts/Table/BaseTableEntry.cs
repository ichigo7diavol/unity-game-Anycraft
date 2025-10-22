using UnityEngine;
using System;
using JetBrains.Annotations;

namespace Anycraft.Features.Configs
{
    [Serializable]
    [UsedImplicitly]
    public abstract partial class BaseTableEntry<TTable, TConfig>
        where TTable : BaseTableConfig<TConfig>
        where TConfig : BaseIdentifiableConfig
    {
        [HideInInspector]
        [SerializeField] private string _id;

        public string Id => _id;
    }
}