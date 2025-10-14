#if UNITY_EDITOR

using Anycraft.Features.OdinExtensions.Windows;
using Anycraft.Features.Configs.Utils;
using Sirenix.OdinInspector;
using UnityEditor;

namespace Anycraft.Features.Configs
{
    public partial class BaseSerializedConfig
    {
        [PropertySpace(spaceBefore:0, spaceAfter:8)]
        [Title("Properties")]
        [LabelText(nameof(Id))]
        [OnValueChanged(nameof(Inspector_UpdateAssetName))]
        [ShowInInspector] public string Inspector_Id
        {
            get => _id;
            set => _id = value;
        }

        protected virtual string Inspector_GetFilePotfix()
        {
            return ConfigUtils.GetConfigAssetName(this);
        }

        protected void Inspector_UpdateAssetName()
        {
            var path = AssetDatabase.GetAssetPath(this);
            var newName = GetType().Name + Inspector_GetFilePotfix();

            AssetDatabase.RenameAsset(path, newName);
            AssetDatabase.SaveAssets();
        }

        [TitleGroup("Validation")]
        [PropertyOrder(int.MinValue)]
        [Button("Validate")]
        private void Inspector_Validate()
        {
            try
            {
                Validate();
            }
            catch (System.Exception e)
            {
                ErrorModalWindow.Show(e.Message);

                throw;
            }
        }
    }
}
#endif