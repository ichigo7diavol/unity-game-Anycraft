#if UNITY_EDITOR

using JetBrains.Annotations;
using UnityEngine.Assertions;

namespace Anycraft.Features.Configs.Utils
{
    [UsedImplicitly]
    public static class ConfigUtils 
    {
        public static string GetConfigAssetName(IConfig config)
        {
            Assert.IsNotNull(config);

            return config == null ? "NotSet" : $"--{config.Id}";
        }
    }
}
#endif