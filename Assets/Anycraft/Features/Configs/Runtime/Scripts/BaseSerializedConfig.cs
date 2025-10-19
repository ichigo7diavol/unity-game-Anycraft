using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Configs
{

    [UsedImplicitly]
    public abstract partial class BaseSerializedConfig
        : ScriptableObject, IConfig
    {
    }
}