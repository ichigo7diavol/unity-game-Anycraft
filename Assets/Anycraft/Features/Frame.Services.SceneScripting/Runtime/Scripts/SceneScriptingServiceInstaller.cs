using Anycraft.Features.Extenions.VContainer;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.Frame.Services.SceneScripting
{
    [UsedImplicitly]
    public abstract class BaseSceneScriptingServiceScriptableInstaller<TSceneScript, TSceneScriptConfig>
        : BaseSceneScriptingServiceScriptableInstaller<TSceneScript>
        where TSceneScript : ISceneScript
        where TSceneScriptConfig : BaseSceneScriptConfig
    {
        [SerializeField] private TSceneScriptConfig _config;

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder
                .RegisterInstance(_config)
                .AsImplementedInterfaces()
                .AsSelf();
        }
    }

    [UsedImplicitly]
    public abstract class BaseSceneScriptingServiceScriptableInstaller<TSceneScript>
        : BaseScriptableInstaller
        where TSceneScript : ISceneScript
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder
                .Register<SceneScriptingService>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            builder
                .Register<TSceneScript>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
        }
    }
}