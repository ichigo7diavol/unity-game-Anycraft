using Anycraft.Features.OdinExtensions.Windows;
using UnityEditor;

namespace Anycraft.Features.FluentValidationExtensions 
{
    public static class ValidationMenu
    {
        [MenuItem("Validation/Validation Window")]
        public static void OpenValidationWindow()
        {
            ModalWindow.Show
            (
                new ModalWindowValidationFailureContext(),
                "Validation Window",
                new UnityEngine.Vector2(600, 300)
            );
        }
    } 
}