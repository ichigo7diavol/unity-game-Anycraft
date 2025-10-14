#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using Anycraft.FluentValidationExtensions.Utilities;
using Sirenix.OdinInspector;

namespace Anycraft.FluentValidationExtensions.Configs.Table
{
    public partial class BaseTableEntry<TTable, TConfig>
    {
        [Required]
        [ValueDropdown(nameof(GetIds))]
        [LabelText(nameof(Id))]
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