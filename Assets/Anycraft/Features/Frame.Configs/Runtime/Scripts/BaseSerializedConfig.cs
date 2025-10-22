using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Frame.Configs
{

    [UsedImplicitly]
    public abstract partial class BaseSerializedConfig
        : ScriptableObject, IConfig
    {
    }
}