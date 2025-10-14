using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.VContainerExtenions.Installers
{
    [UsedImplicitly]
    public abstract partial class ScriptableContainerInstaller
        : ScriptableObject, IContainerInstaller
    {
        public virtual void Install(IContainerBuilder builder)
        {
            UnityEngine.Assertions.Assert.IsNotNull(builder);
        }
    }
}