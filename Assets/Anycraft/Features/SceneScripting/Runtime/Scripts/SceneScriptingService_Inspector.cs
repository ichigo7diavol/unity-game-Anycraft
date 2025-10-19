using Sirenix.OdinInspector;

namespace Anycraft.Features.SceneScripting
{
    public partial class SceneScriptingService
    {
        [LabelText(nameof(_script))]
        [ShowInInspector()] private ISceneScript Inspector_Script => _script;
    }
}