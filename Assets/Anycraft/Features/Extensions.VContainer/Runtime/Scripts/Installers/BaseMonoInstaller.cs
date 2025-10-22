using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer;

namespace Anycraft.Features.VContainerExtenions.Installers
{
    [UsedImplicitly]
    public abstract class BaseMonoInstaller
        : MonoBehaviour, IInstaller
    {
        public virtual void Install(IContainerBuilder builder)
        {
            Assert.IsNotNull(builder);
        }
    }
}