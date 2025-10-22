using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Frame.Configs
{
    [UsedImplicitly]
    public abstract partial class BaseIdentifiableConfig
        : BaseSerializedConfig
    {
        [SerializeField] public string _id;
        
        public string Id => _id;
    }
}