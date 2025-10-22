using VContainer;
using VContainer.Unity;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.Assertions;

namespace Anycraft.Features.Extenions.VContainer
{

    [UsedImplicitly]
    public abstract class BaseLifetimeScope
        : LifetimeScope
    {
        [SerializeField] private List<BaseMonoInstaller> _monoInstallers = new();
        [SerializeField] private List<BaseScriptableInstaller> _scriptableInstallers = new();

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
