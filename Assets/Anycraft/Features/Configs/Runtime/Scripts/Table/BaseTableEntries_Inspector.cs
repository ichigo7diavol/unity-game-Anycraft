#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Anycraft.Features.Utilities;

namespace Anycraft.Features.Configs.Table
{
    public partial class BaseTableEntries<TTable, TConfig>
    {
        [ValueDropdown(nameof(GetIds))]
        [LabelText(nameof(Ids))]
        [ListDrawerSettings(ElementColor = nameof(ElementColor))]
        [ShowInInspector] private List<string> Inspector_Ids
        {
            get => _ids;
            set => _ids = value;
        }

        private IEnumerable<string> GetIds()
        {
            var table = EditorUtils.LoadFirstAssetOfType<TTable>();

            return table.Configs.Select(e => e.Id);
        }
        
        private Color ElementColor(int index, Color color)
        {
            var value = _ids[index];

            if (string.IsNullOrEmpty(value))
            {
                return Color.red;
            }
            if (_ids.Count(e => e == value) >= 2)
            {
                return Color.red;
            }
            return color;
        }
    }
}
#endif