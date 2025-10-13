using System.Text;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.VContainerExtenions
{
    [UsedImplicitly]
    public abstract class MonoContainerInstaller : MonoBehaviour, IContainerInstaller
    {
        public virtual void Install(IContainerBuilder builder)
        {
            NUnit.Framework.Assert.IsNotNull(builder);
        }
    }
}