using Sirenix.OdinInspector;

namespace Anycraft.Features.Items.Configs
{
    public sealed partial class ItemConfig
    {
        [LabelText(nameof(Tags))]
        [ShowInInspector]
        private ItemTagTableEntries Inspector_Tags
        {
            get => _tags;
            set => _tags = value;
        }
    }
}

