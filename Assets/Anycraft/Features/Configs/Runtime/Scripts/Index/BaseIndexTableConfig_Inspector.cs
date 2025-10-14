#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
using Anycraft.Features.OdinExtensions.Windows;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Configs.Index
{
    public partial class BaseIndexTableConfig<TConfig>
    {
        [ListDrawerSettings(ElementColor = nameof(ElementColor))]
        [ShowInInspector]
        public List<TConfig> Inspector_Configs
        {
            get => _configs;
            set => _configs = value;
        }
        
        [TitleGroup("Validation")]
        [PropertySpace]
        [Button("Validate Table")]
        private void Inspector_ValidateTable()
        {
            var errors = ListPool<string>.New();

            for (var i = 0; i < _configs.Count; i++)
            {
                var config = _configs[i];
                try
                {
                    config.Validate();
                }
                catch (Exception e)
                {
                    errors.Add($"{nameof(Configs)}[{i}]: {e.Message}");
                }
            }
            if (errors.Any())
            {
                ErrorModalWindow.Show(string.Join('\n', errors));
            }
            errors.Clear();
            ListPool<string>.Free(errors);
        }

        [Button("Sort By Index")]
        private void Sort()
        {
            _configs.Sort((left, right) => left.Index.CompareTo(right.Index));
        }

        private Color ElementColor(int index, Color color)
        {
            var value = _configs[index];

            if (value == null)
            {
                return Color.red;
            }
            if (_configs.Count(e => e.Id == value.Id) >= 2)
            {
                return Color.red;
            }
            return color;
        }
    }
}
#endif