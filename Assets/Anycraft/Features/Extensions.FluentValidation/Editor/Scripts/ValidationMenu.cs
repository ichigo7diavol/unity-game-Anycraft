using Anycraft.Features.Extensions.Odin;
using UnityEditor;

namespace Anycraft.Features.Extensions.FluentValidation 
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