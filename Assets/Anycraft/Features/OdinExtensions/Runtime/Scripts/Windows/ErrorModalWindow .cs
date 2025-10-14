using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEngine;
using UnityEditor;
using Sirenix.Utilities.Editor;
using Sirenix.Utilities;

namespace Anycraft.Features.OdinExtensions.Windows
{
    public class ErrorModalWindow
        : OdinEditorWindow
    {
        [ReadOnly, MultiLineProperty(10)]
        [ShowInInspector]
        [LabelText("Error")]
        [PropertyOrder(0)]
        [GUIColor(1, 0.8f, 0.8f)]
        private string errorText;

        [ShowInInspector, PropertyOrder(1)]
        [Button(ButtonSizes.Medium)]
        private void CopyToClipboard()
        {
            EditorGUIUtility.systemCopyBuffer = errorText;
            Debug.Log("Copyed to clipboard.");
        }

        public static void Show(string message)
        {
            var window = CreateInstance<ErrorModalWindow>();
            window.minSize = new Vector2(600, 225);
            window.maxSize = new Vector2(600, 225);
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(500, 250);
            window.errorText = message;
            window.titleContent = new GUIContent("Validation error");
            window.ShowUtility();
        }
    }
}