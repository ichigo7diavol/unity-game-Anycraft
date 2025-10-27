using Anycraft.Features.Frame.Services.SceneScripting;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Scenes.Main
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Scenes) + "/" + nameof(Main) + "/" + nameof(MainSceneScriptingServiceScriptableInstaller))]
    public sealed class MainSceneScriptingServiceScriptableInstaller
        : BaseSceneScriptingServiceScriptableInstaller<MainSceneScript>
    {
    }
}