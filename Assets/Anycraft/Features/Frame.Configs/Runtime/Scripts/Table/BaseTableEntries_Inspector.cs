#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Anycraft.Features.Frame.Utilities;

namespace Anycraft.Features.Frame.Configs
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