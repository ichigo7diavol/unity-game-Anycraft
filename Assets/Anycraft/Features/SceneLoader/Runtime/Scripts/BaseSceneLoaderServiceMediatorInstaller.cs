using Anycraft.Features.VContainerExtenions.Installers;
using JetBrains.Annotations;
using VContainer;

namespace Anycraft.Features.SceneLoader
{
    [UsedImplicitly]
    public abstract class BaseSceneLoaderServiceMediatorInstaller<TSceneLoaderServiceMediator>
        : BaseScriptableInstaller
        where TSceneLoaderServiceMediator : BaseSceneLoaderServiceMediator
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder.Register<TSceneLoaderServiceMediator>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
        }
    }
}