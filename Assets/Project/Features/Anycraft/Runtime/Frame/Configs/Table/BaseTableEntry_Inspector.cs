#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Anycraft.Utils;

namespace Anycraft.Frame.Configs.Table
{
    public partial class BaseTableEntry<TTable, TConfig>
    {
        [ValueDropdown(nameof(GetIds))]
        [LabelText("Id")]
        [ShowInInspector] private string Inspector_Id
        {
            get => _id;
            set => _id = value;
        }
    
        private IEnumerable<string> GetIds()
        {
            var table = EditorUtils.LoadFirstAssetOfType<TTable>();

            return table.Configs.Select(e => e.Id);
        }
    }
}
#endif