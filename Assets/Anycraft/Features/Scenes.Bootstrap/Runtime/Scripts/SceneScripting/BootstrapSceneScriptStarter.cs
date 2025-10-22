using Anycraft.Features.Frame.Services.SceneScripting;
using JetBrains.Annotations;

namespace Anycraft.Features.Scenes.SceneBootstrap
{

    [UsedImplicitly]
    public sealed class BootstrapSceneScriptStarter
        : BaseSceneScriptStarter<BootstrapSceneScript>
    {
        public BootstrapSceneScriptStarter(SceneScriptingService service) 
            : base(service)
        {
        }
    }
}