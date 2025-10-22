using Anycraft.Features.Extenions.VContainer;
using JetBrains.Annotations;
using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.Frame.Services.SceneLoader
{
    [UsedImplicitly]
    public abstract class BaseSceneLoaderServiceMediatorInstaller<
        TSceneLoaderServiceMediator, TSceneLoaderServiceMediatorConfig>
        : BaseScriptableInstaller
        where TSceneLoaderServiceMediator : BaseSceneLoaderServiceMediator
        where TSceneLoaderServiceMediatorConfig : BaseSceneLoaderServiceMediatorConfig
    {
        [Required]
        [SerializeField] private TSceneLoaderServiceMediatorConfig _config;

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            Assert.IsNotNull(_config);

            builder.Register<TSceneLoaderServiceMediator>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.RegisterInstance(_config)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.AsLazy<TSceneLoaderServiceMediator>();
        }
    }
}