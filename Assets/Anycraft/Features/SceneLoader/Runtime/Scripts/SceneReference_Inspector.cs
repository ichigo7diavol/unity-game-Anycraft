#if UNITY_EDITOR

using Sirenix.OdinInspector;
using UnityEditor;

namespace Anycraft.Features.SceneLoader
{
    public sealed partial class SceneReference
    {
        [InfoBox("Scene not added to build", VisibleIf = nameof(IsBeingBuilt), InfoMessageType = InfoMessageType.Error)]
        [LabelText("Scene Asset")]
        [OnValueChanged(nameof(UpdateSerializedData))]
        [ShowInInspector] private SceneAsset Inspector_SceneAsset;
        
        [LabelText(nameof(Path))]
        [ShowInInspector] private string Inspector_Path => _path;

        [LabelText(nameof(BuildIndex))]
        [ShowInInspector] private int Inspector_BuildIndex => _buildIndex;

        private bool IsBeingBuilt => !CheckIfInBuild();

        private void UpdateSerializedData()
        {
            if (Inspector_SceneAsset == null)
            {
                _path = string.Empty;
                return;
            }
            var path = AssetDatabase.GetAssetPath(Inspector_SceneAsset);
            _path = System.IO.Path.GetFileNameWithoutExtension(path);

            for (var i = 0; i < EditorBuildSettings.scenes.Length; i++)
            {
                var setting = EditorBuildSettings.scenes[i];

                if (setting.path == path)
                {
                    _buildIndex = i;
                    break;
                }
            }
        }

        private bool CheckIfInBuild()
        {
            foreach (var s in EditorBuildSettings.scenes)
            {
                if (s.enabled && System.IO.Path
                    .GetFileNameWithoutExtension(s.path) == Inspector_Path)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
#endif