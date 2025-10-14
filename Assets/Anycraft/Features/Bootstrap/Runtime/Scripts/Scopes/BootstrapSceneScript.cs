using Anycraft.FluentValidationExtensions.SceneScripting;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Bootstrap.Scopes
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(FluentValidationExtensions) + "/" + nameof(Bootstrap) + "/" + nameof(Scopes) + "/" + nameof(BootstrapSceneScript))]
    public sealed class BootstrapSceneScript : BaseSceneScript
    {
        public override void Validate()
        {
        }
    }
}