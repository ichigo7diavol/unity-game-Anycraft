using System;
using System.Collections.Generic;
using Anycraft.Features.Items.Configs;
using UnityEngine;

namespace Anycraft.Features.Items
{
    [Serializable]
    public sealed class ItemFilter
    {
        [SerializeField] private List<ItemConfig> _includes;
        [SerializeField] private List<ItemConfig> _excludes;

        public IReadOnlyList<ItemConfig> Includes => _includes;
        public IReadOnlyList<ItemConfig> Excludes => _excludes;

        public IEnumerable<ItemConfig> Apply(IEnumerable<ItemConfig> configs)
        {
            foreach (var config in configs)
            {
                // if (Excludes.Contains(config))
                // {
                //     continue;
                // }
                // if (Includes.Contains(config))
                // {
                //     yield return config;
                // }
                // if (config.TagsData.Tags.Any(t => Tags.IsHasTag(t)))
                // {
                //     yield return config;
                // }
            }
            return null;
        }
    }
}

