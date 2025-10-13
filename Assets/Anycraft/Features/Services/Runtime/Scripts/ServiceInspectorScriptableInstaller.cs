using Anycraft.Features.VContainerExtenions;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.Services
{
    [UsedImplicitly]
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