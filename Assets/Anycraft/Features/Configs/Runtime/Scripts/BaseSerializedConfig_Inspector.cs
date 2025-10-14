#if UNITY_EDITOR

using Anycraft.Features.Configs.Utils;
using Sirenix.OdinInspector;
using UnityEditor;

namespace Anycraft.Features.Configs
{
    public partial class BaseSerializedConfig
    {
        private bool Inpector_ValidationErrorIsVisible { get; set; }
        private string Inpector_ValidationError;
        
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

        [Title("Validation")]
        [PropertyOrder(int.MinValue)]
        [InfoBox("$" + nameof(Inpector_ValidationError),
            VisibleIf = nameof(Inpector_ValidationErrorIsVisible),
            InfoMessageType = InfoMessageType.Error)]
        [Button("Validate")]
        private void Inspector_Validate()
        {
            Inpector_ValidationErrorIsVisible = false;

            try
            {
                Validate();
            }
            catch (System.Exception e)
            {
                Inpector_ValidationErrorIsVisible = true;
                Inpector_ValidationError = e.Message;

                throw;
            }
        }
    }
}
#endif