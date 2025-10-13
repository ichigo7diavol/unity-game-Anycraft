#if UNITY_EDITOR

using Sirenix.OdinInspector;
using UnityEditor;

namespace Anycraft.Features.Configs
{
    public partial class ConfigContainer
    {
        [LabelText(nameof(Config))]
        [OnValueChanged(nameof(Inspector_UpdateAssetName))]
        [ShowInInspector] private IConfig Inspector_Config
        {
            get => _config;
            set => _config = value;
        }

        private void Inspector_UpdateAssetName()
        {
            var path = AssetDatabase.GetAssetPath(this);
            var newName = _config == null 
                ? "Empty-Container"
                : $"{_config.GetType().Name}-Container";

            AssetDatabase.RenameAsset(path, newName);
            AssetDatabase.SaveAssets();
        }
    }
}
#endif