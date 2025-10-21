using Anycraft.Features.VContainerExtenions.Installers;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.SceneScripting
{
    [UsedImplicitly]
    public abstract class BaseSceneScriptStarterInstaller<TScriptStarter, TSceneScript, TData>
        : BaseScriptableInstaller
        where TScriptStarter : BaseSceneScriptStarter<TSceneScript, TData>
        where TSceneScript : ISceneScript, ISceneScriptStartable<TData>
    {
        [Required]
        [SerializeField] private TData _data;

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder
                .Register<TScriptStarter>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            builder
                .RegisterInstance(_data)
                .AsImplementedInterfaces()
                .AsSelf();
        }
    }

    [UsedImplicitly]
    public abstract class BaseSceneScriptStarterInstaller<TScriptStarter, TSceneScript>
        : BaseScriptableInstaller
        where TScriptStarter : BaseSceneScriptStarter<TSceneScript>
        where TSceneScript : ISceneScript, ISceneScriptStartable
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder
                .Register<TScriptStarter>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
        }
    }
}