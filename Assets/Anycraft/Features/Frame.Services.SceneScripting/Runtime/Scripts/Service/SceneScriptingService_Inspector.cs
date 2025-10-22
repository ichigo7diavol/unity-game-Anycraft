using Sirenix.OdinInspector;

namespace Anycraft.Features.Frame.Services.SceneScripting
{
    public partial class SceneScriptingService
    {
        [LabelText(nameof(_script))]
        [ShowInInspector()] private ISceneScript Inspector_Script => _script;
    }
}