using UnityEngine;
using System;
using JetBrains.Annotations;

namespace Anycraft.FluentValidationExtensions.Configs.Table
{
    [Serializable]
    [UsedImplicitly]
    public abstract partial class BaseTableEntry<TTable, TConfig>
        where TTable : BaseTableConfig<TConfig>
        where TConfig : BaseSerializedConfig
    {
        [HideInInspector]
        [SerializeField] private string _id;

        public string Id => _id;
    }
}