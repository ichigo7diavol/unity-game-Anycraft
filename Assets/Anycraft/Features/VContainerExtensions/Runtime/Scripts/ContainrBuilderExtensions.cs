using VContainer;
using UnityEngine;
using JetBrains.Annotations;

namespace Anycraft.Features.VContainerExtenions
{
    [UsedImplicitly]
    public static class ContainrBuilderExtensions
    {
        public static void AsLazy<T>(this IContainerBuilder builder)
        {
            builder.RegisterBuildCallback(resolver => resolver.Resolve<T>());
        } 
    } 
}
