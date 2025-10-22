using System.Collections.Generic;
using Anycraft.Features.FluentValidationExtensions;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer;
using System;

namespace Anycraft.Features.VContainerExtenions.Installers
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