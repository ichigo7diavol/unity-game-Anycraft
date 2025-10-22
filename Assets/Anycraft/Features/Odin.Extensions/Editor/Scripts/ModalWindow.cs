using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEngine;
using Sirenix.Utilities.Editor;
using Sirenix.Utilities;

namespace Anycraft.Features.OdinExtensions.Windows
{
    public sealed class ModalWindow
        : OdinEditorWindow
    {
        [HideLabel]
        [InlineProperty]
        [HideReferenceObjectPicker]
        [ShowInInspector] private object _context;

        [PropertySpace]
        [Button("Ok", ButtonSizes.Medium)]
        private void OnOkButtonClicked()
        {
            Close();
        }

        public static void Show(object context, string header, Vector2 size)
        {
            var window = CreateInstance<ModalWindow>();

            window._context = context;

            window.titleContent = new GUIContent(header);
            
            window.minSize = size;
            window.maxSize = size;

            window.position = GUIHelper
                .GetEditorWindowRect()
                .AlignCenter(500, 250);

            window.ShowUtility();
        }
    }
}