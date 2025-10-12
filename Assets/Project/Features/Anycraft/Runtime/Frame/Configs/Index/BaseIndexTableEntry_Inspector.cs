#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace Anycraft.Frame.Configs.Index
{
    public partial class BaseIndexTableEntry<TTable, TConfig>
    {
        [ValueDropdown(nameof(Getindexes))]
        [LabelText("Id")]
        [ShowInInspector] private int Inspector_Index
        {
            get => _index;
            set => _index = value;
        }
    
        private IEnumerable<int> Getindexes()
        {
            var table = EditorUtils.LoadFirstAssetOfType<TTable>();

            return table.Configs.Select(e => e.Index);
        }
    }
}
#endif