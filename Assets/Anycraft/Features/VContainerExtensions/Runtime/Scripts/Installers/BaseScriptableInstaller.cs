using Anycraft.Features.FluentValidationExtensions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer;

namespace Anycraft.Features.VContainerExtenions.Installers
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(VContainerExtenions) + "/" + nameof(Installers) + "/" + nameof(BaseScriptableInstaller))]
    public abstract partial class BaseScriptableInstaller
        : ScriptableObject, IInstaller, IValidatable
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