using Anycraft.Features.Frame.Services.SceneScripting;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Scenes.SceneMenu
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Scenes) + "/" + nameof(SceneMenu) + "/" + nameof(MenuSceneScriptingServiceScriptableInstaller))]
    public sealed class MenuSceneScriptingServiceScriptableInstaller
        : BaseSceneScriptingServiceScriptableInstaller<MenuSceneScript>
    {
    }
}