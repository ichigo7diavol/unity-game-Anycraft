#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using Anycraft.Features.Utilities;
using Sirenix.OdinInspector;

namespace Anycraft.Features.Configs.Index
{
    public partial class BaseIndexTableEntry<TTable, TConfig>
    {
        [ValueDropdown(nameof(GetIndexes))]
        [LabelText("Id")]
        [ShowInInspector] private int Inspector_Index
        {
            get => _index;
            set => _index = value;
        }
    
        private IEnumerable<int> GetIndexes()
        {
            var table = EditorUtils.LoadFirstAssetOfType<TTable>();

            return table.Configs.Select(e => e.Index);
        }
    }
}
#endif