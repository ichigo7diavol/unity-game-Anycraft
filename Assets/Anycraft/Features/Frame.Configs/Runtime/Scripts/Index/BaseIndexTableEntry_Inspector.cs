using Sirenix.OdinInspector;

namespace Anycraft.Features.Frame.Configs
{
    public abstract partial class BaseIndexTableEntry<TTable, TConfig>
    {
        [LabelText(nameof(Index))]
        [ShowInInspector] public int Inspector_Index => _index;
    }
}