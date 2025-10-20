#if UNITY_EDITOR

using System.Collections.Generic;
using Anycraft.Features.Utilities;
using Sirenix.OdinInspector;

namespace Anycraft.Features.Configs
{
    public partial class BaseIndexTableConfig<TConfig>
    {
        [ShowInInspector]
        public List<TConfig> Inspector_Configs
        {
            get => _configs;
            set => _configs = value;
        }

        [Button("Sort By Index")]
        private void Sort()
        {
            _configs.Sort((left, right) => left.Index.CompareTo(right.Index));
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