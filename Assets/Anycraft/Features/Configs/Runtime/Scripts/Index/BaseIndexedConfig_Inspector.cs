using Sirenix.OdinInspector;

namespace Anycraft.Features.Configs.Index
{
    public abstract partial class BaseIndexedConfig
        : BaseSerializedConfig
    {
        [LabelText(nameof(Index))]
        [OnValueChanged(nameof(Inspector_UpdateAssetName))]
        [ShowInInspector]
        private int Inpector_Index
        {
            get => _index;
            set => _index = value;
        }

        protected override string Inspector_GetFilePotfix()
        {
            return $"{base.Inspector_GetFilePotfix()}--{_index}";
        }
    }
}