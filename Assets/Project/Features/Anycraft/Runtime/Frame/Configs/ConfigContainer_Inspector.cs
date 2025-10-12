#if UNITY_EDITOR

using UnityEditor;

namespace Anycraft.Frame.Configs
{
    public partial class ConfigContainer
    {
        partial void UpdateAssetName()
        {
            var path = AssetDatabase.GetAssetPath(this);
            var newName = _config == null 
                ? GetType().Name
                : _config.GetType().Name + $"Container--{_config.Id}";

            AssetDatabase.RenameAsset(path, newName);
            AssetDatabase.SaveAssets();
        }
    }
}
#endif