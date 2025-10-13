using VContainer;
using VContainer.Unity;
using UnityEngine;
using System.Collections.Generic;
using Anycraft.Features.Validation;
using JetBrains.Annotations;

namespace Anycraft.Features.VContainerExtenions
{
    [UsedImplicitly]
    public abstract class BaseLifetimeScope : LifetimeScope, IValidatable
    {
        [SerializeField] private List<MonoContainerInstaller> _monoInstallers = new();
        [SerializeField] private List<ScriptableContainerInstaller> _scriptableInstallers = new();

        public bool Validate(ref string errorMessage)
        {
            return true; 
        }

        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var installer in _monoInstallers)
            {
                installer.ValidateAndThrow();
                installer.Install(builder);
            }
            foreach (var installer in _scriptableInstallers)
            {
                installer.ValidateAndThrow();
                installer.Install(builder);
            }
        }
    }
}
