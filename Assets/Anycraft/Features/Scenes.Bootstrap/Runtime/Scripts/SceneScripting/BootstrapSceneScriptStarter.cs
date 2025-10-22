using Anycraft.Features.SceneScripting;
using JetBrains.Annotations;

namespace Anycraft.Features.SceneBootstrap
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