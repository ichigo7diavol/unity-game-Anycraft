using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.FluentValidationExtensions.Services
{
    [UsedImplicitly]
    public sealed partial class ServicesInspector : MonoBehaviour
    {
        private IReadOnlyList<IService> _services;

        [Inject]
        public void Construct(IReadOnlyList<IService> services)
        {
            _services = services;
        }
    }
}