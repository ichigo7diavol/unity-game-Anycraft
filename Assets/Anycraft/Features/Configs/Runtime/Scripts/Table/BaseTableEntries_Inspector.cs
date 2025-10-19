#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Anycraft.Features.Utilities;

namespace Anycraft.Features.Configs.Table
{
    public partial class BaseTableEntries<TTable, TConfig>
    {
        [ValueDropdown(nameof(GetIds))]
        [LabelText(nameof(Ids))]
        [ShowInInspector] private List<string> Inspector_Ids
        {
            get => _ids;
            set => _ids = value;
        }

        private IEnumerable<string> GetIds()
        {
            var table = RuntimeEditorUtils.LoadFirstAssetOfType<TTable>();

            return table.Configs.Select(c => c.Id);
        }
    }
}
#endif