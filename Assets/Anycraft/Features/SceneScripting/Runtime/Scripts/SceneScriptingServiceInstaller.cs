using Anycraft.Features.VContainerExtenions.Installers;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.SceneScripting
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(SceneScripting) + "/" + nameof(SceneScriptingServiceScriptableInstaller))]
    public sealed class SceneScriptingServiceScriptableInstaller
        : ScriptableContainerInstaller
    {
        [SerializeField] private BaseSceneScript _script;

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder
                .Register<SceneScriptingService>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.RegisterInstance(_script);
        }
    }
}