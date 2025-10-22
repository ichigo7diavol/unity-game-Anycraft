#if UNITY_EDITOR

using System.Collections.Generic;
using Anycraft.Features.Frame.Utilities;
using Sirenix.OdinInspector;

namespace Anycraft.Features.Frame.Configs
{
    public partial class BaseTableConfig<TConfig>
    {
        [LabelText(nameof(Configs))]
        [ShowInInspector] private List<TConfig> Inspector_configs
        {
            get => _configs;
            set => _configs = value;
        }

        [Button("Update Table")]
        private void Inspector_UpdateTable()
        {
            _configs.Clear();

            var sequence = RuntimeEditorUtils
                .LoadAssetsOfType<TConfig>();

            _configs.AddRange(sequence);
        }
    }
}
#endif