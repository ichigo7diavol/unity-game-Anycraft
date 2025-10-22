using VContainer;
using UnityEngine;
using JetBrains.Annotations;

namespace Anycraft.Features.Extenions.VContainer
{
    [UsedImplicitly]
    public static class ContainerBuilderExtensions
    {
        public static void AsLazy<T>(this IContainerBuilder builder)
        {
            builder.RegisterBuildCallback(resolver => resolver.Resolve<T>());
        } 
    } 
}
