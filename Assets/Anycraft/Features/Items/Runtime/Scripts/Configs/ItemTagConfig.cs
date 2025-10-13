using Anycraft.Features.Tags.Configs;
using UnityEngine;

namespace Anycraft.Features.Items.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Items/Configs/" + nameof(ItemTagConfig))]
    public sealed class ItemTagConfig : BaseTagConfig
    {
        public override void Validate()
        {
        }
    }
}

