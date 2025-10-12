using System;
using Anycraft.Frame.Configs;
using UnityEngine;

namespace Anycraft.Resource
{
    [CreateAssetMenu(menuName = "Anycraft/Resource/" + nameof(ResourceConfig))]
    public sealed class ResourceConfig : SerializedConfig
    {
    }
}