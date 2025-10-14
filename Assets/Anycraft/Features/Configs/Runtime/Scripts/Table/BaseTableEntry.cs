using UnityEngine;
using System;
using JetBrains.Annotations;
using Anycraft.Features.Validation;

namespace Anycraft.Features.Configs.Table
{
    [Serializable]
    [UsedImplicitly]
    public abstract partial class BaseTableEntry<TTable, TConfig>
        : IValidatable
        where TTable : BaseTableConfig<TConfig>
        where TConfig : BaseSerializedConfig
    {
        [HideInInspector]
        [SerializeField] private string _id;

        public string Id => _id;
    }
}