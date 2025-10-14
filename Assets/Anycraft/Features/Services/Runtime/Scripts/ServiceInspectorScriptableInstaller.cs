using Anycraft.FluentValidationExtensions.VContainerExtenions;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.FluentValidationExtensions.Services
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(FluentValidationExtensions) + "/" + nameof(Services) + "/" + nameof(ServiceInspectorScriptableInstaller))]
    public sealed class ServiceInspectorScriptableInstaller : ScriptableContainerInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            var gameObject = new GameObject($"[{nameof(ServicesInspector)}]");
            gameObject.AddComponent<ServicesInspector>();

            builder.RegisterInstance(gameObject).AsSelf();
        }
    }
}