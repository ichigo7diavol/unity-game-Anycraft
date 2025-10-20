using Anycraft.Features.VContainerExtenions.Installers;
using JetBrains.Annotations;
using MessagePipe;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.SceneLoader
{
    [UsedImplicitly]
    public abstract class SceneLoaderServiceInstaller<TSceneLoaderServiceMediator>
        : SceneLoaderServiceInstaller
        where TSceneLoaderServiceMediator : BaseSceneLoaderServiceMediator
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);
        }
    }

    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(SceneLoader) + "/" + nameof(SceneLoaderServiceInstaller))]
    public class SceneLoaderServiceInstaller
        : BaseScriptableInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder.Register<SceneLoaderService>(Lifetime.Scoped)
                .AsImplementedInterfaces()
                .AsSelf();

            // var msgOptions = builder.RegisterMessagePipe().
            // builder.RegisterMessageBroker<SceneLoadingStartedEvent>();
            // builder.RegisterMessageBroker<SceneLoadingStartedEvent>();
        }
    }
}