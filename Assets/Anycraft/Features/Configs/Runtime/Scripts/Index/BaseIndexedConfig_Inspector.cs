using Sirenix.OdinInspector;

namespace Anycraft.Features.Configs
{
    public abstract partial class BaseIndexedConfig
    {
        [LabelText(nameof(Index))]
        [ShowInInspector]
        private int Inpector_Index
        {
            get => _index;
            set => _index = value;
        }
    }
}