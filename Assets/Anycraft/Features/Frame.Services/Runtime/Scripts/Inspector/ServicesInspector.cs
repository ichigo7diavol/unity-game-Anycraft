using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.Services
{
    [UsedImplicitly]
    public sealed partial class ServicesInspector : MonoBehaviour
    {
        private IReadOnlyList<IService> _services;

        [Inject]
        public void Construct(IEnumerable<IService> services)
        {
            _services = services.ToList();
        }
    }
}