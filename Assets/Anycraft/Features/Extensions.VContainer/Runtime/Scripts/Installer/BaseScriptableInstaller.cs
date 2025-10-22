using Anycraft.Features.Extensions.FluentValidation;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer;

namespace Anycraft.Features.Extenions.VContainer
{
    [UsedImplicitly]
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