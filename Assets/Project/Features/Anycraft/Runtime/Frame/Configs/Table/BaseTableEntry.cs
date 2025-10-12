using UnityEngine;
using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Linq;

namespace Anycraft.Frame.Configs.Table
{
    [Serializable]
    public abstract partial class BaseTableEntry<TTable, TConfig>
        where TTable : BaseTableConfig<TConfig>
        where TConfig : SerializedConfig
    {
        [HideInInspector]
        [SerializeField] private string _id;
    }
}