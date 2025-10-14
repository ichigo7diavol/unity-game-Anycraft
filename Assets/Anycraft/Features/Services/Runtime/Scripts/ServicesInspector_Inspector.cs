using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Anycraft.Features.Services
{
    public partial class ServicesInspector
    {
        [ShowInInspector] private IReadOnlyList<IService> Inspector_Services => _services;

    }
}