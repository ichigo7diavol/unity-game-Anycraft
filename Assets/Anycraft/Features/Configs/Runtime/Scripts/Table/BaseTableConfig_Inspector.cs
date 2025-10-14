#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using Anycraft.Features.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Anycraft.Features.Configs.Table
{
    public partial class BaseTableConfig<TConfig>
    {
        [LabelText(nameof(Configs))]
        [ListDrawerSettings(ElementColor = nameof(ElementColor))]
        [ShowInInspector] private List<TConfig> Inspector_configs
        {
            get => _configs;
            set => _configs = value;
        }

        [Button("Update Table")]
        private void Inspector_UpdateTable()
        {
            _configs.Clear();

            var sequence = EditorUtils
                .LoadAssetsOfType<TConfig>();

            _configs.AddRange(sequence);
        }

        private Color ElementColor(int index, Color color)
        {
            var value = _configs[index];

            if (value == null)
            {
                return Color.red;
            }
            if (_configs.Count(e => e != null && e.Id == value.Id) >= 2)
            {
                return Color.red;
            }
            return color;
        }
    }
}
#endif