using Anycraft.Features.FluentValidationExtensions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer;

namespace Anycraft.Features.VContainerExtenions.Installers
{
    [UsedImplicitly]
    public abstract partial class ScriptableContainerInstaller
        : ScriptableObject, IContainerInstaller, IValidatable
    {
        public virtual void Install(IContainerBuilder builder)
        {
            Assert.IsNotNull(builder);
        }

        public virtual void Validate()
        {
        }
    }
}