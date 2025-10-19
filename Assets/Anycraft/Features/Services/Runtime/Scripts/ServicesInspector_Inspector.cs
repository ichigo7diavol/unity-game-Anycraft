using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Anycraft.Features.Services
{
    public partial class ServicesInspector
    {
        [LabelText(nameof(_services))]
        [ShowInInspector] private IReadOnlyList<IService> Inspector_Services
            => _services;

    }
}