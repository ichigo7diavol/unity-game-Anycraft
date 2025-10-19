using Anycraft.Features.Configs;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Anycraft.Features.SceneLoader
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(SceneLoader) + "/" + nameof(SceneLoaderServiceConfig))]
    public sealed class SceneLoaderServiceConfig
        : BaseSerializedConfig
    {
        [Required]
        [SerializeField] private SceneReference _loadingSceneReference;

        public override void Validate()
        {
        }
    }
}