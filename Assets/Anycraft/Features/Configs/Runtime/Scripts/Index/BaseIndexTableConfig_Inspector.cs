#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Configs.Index
{
    public partial class BaseIndexTableConfig<TConfig>
    {
        [ListDrawerSettings(ElementColor = nameof(ElementColor))]
        [ShowInInspector] public List<TConfig> Inspector_Configs
        {
            get => _configs;
            set => _configs = value;
        }

        [Button("Sort By Index")]
        private void Sort()
        {
            _configs.Sort((left, right) => left.Index.CompareTo(right.Index));
        }

        private Color ElementColor(int index, Color color)
        {
            var value = _configs[index];

            if (value == null)
            {
                return Color.red;
            }
            if (_configs.Count(e => e.Id == value.Id) >= 2)
            {
                return Color.red;
            }
            return color;
        }
    }
}
#endif