using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.Overlays;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[Overlay(typeof(EditorWindow), "Scene Selector", true)]
public class GlobalSceneSelectorOverlay : Overlay
{
    public override VisualElement CreatePanelContent()
    {
        var button = new ToolbarMenu();
        button.text = EditorSceneManager.GetActiveScene().name;

        RefreshMenu(button);
        return button;
    }

    private void RefreshMenu(ToolbarMenu button)
    {
        button.menu.MenuItems().Clear();
        var sceneGuids = AssetDatabase.FindAssets("t:Scene");

        foreach (var guid in sceneGuids)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var sceneName = System.IO.Path.GetFileNameWithoutExtension(path);

            button.menu.AppendAction(sceneName, _ =>
            {
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    EditorSceneManager.OpenScene(path);
                    button.text = sceneName;
                }
            });
        }
    }
}
