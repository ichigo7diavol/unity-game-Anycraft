#if UNITY_EDITOR

using Sirenix.OdinInspector;

namespace Anycraft.Features.Tags.Configs
{
    public abstract partial class BaseTagConfig
    {
        private bool Inpector_ValidationErrorIsVisible { get; set; }
        private string Inpector_ValidationError;

        [PropertyOrder(int.MaxValue)]
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