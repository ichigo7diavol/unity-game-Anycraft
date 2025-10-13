using VContainer;
using VContainer.Unity;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.Assertions;

namespace Anycraft.Features.VContainerExtenions
{
    [UsedImplicitly]
    public abstract class BaseLifetimeScope : LifetimeScope
    {
        [SerializeField] private List<MonoContainerInstaller> _monoInstallers = new();
        [SerializeField] private List<ScriptableContainerInstaller> _scriptableInstallers = new();

        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var installer in _monoInstallers)
            {
                Assert.IsNotNull(installer);

                installer.Install(builder);
            }
            foreach (var installer in _scriptableInstallers)
            {
                Assert.IsNotNull(installer);

                installer.Install(builder);
            }
        }
    }
}
