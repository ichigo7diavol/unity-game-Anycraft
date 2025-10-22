using Anycraft.Features.Frame.Services.SceneLoader;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Anycraft.Features.Scenes.Global
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Global) + "/" + nameof(GlobalSceneLoaderServiceMediatorConfig))]
    public sealed class GlobalSceneLoaderServiceMediatorConfig
        : BaseSceneLoaderServiceMediatorConfig
    {
        [Required]
        [SerializeField] private SceneReference _bootstrapSceneReference;

        [Required]
        [SerializeField] private SceneReference _menuSceneReference;

        public SceneReference BootstrapSceneReference => _bootstrapSceneReference;
        public SceneReference MenuSceneReference => _menuSceneReference;
    }
}