#if UNITY_EDITOR

using Anycraft.Features.OdinExtensions.Windows;
using Sirenix.OdinInspector;

namespace Anycraft.Features.VContainerExtenions.Installers
{
    public abstract partial class ScriptableContainerInstaller
    {
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