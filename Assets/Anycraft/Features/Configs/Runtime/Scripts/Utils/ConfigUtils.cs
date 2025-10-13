#if UNITY_EDITOR

namespace Anycraft.Features.Configs.Utils
{
    public static class ConfigUtils 
    {
        public static string GetConfigAssetName(IConfig config)
        {
            return config == null ? "NotSet" : $"--{config.Id}";
        }
    }
}
#endif