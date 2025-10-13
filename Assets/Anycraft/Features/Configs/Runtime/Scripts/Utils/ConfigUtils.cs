#if UNITY_EDITOR

using JetBrains.Annotations;

namespace Anycraft.Features.Configs.Utils
{
    [UsedImplicitly]
    public static class ConfigUtils 
    {
        public static string GetConfigAssetName(IConfig config)
        {
            return config == null ? "NotSet" : $"--{config.Id}";
        }
    }
}
#endif