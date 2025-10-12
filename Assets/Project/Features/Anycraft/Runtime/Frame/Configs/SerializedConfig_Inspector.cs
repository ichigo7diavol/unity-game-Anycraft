#if UNITY_EDITOR

using UnityEditor;

namespace Anycraft.Frame.Configs
{
    public partial class BaseSerializedConfig
    {   
        partial void UpdateAssetName()
        {
            var path = AssetDatabase.GetAssetPath(this);
            var newName = GetType().Name + $"--{Id}";

            AssetDatabase.RenameAsset(path, newName);
            AssetDatabase.SaveAssets();
        }
    }
}
#endif