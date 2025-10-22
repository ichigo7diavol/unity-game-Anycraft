#if UNITY_EDITOR

using System.Collections.Generic;
using FluentValidation;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Anycraft.Features.Extensions.FluentValidation
{
    public partial class ModalWindowValidationFailureContext
    {
        public partial struct FailureEntry
        {
            [LabelText(nameof(Validatable))]
            [ShowInInspector] IValidatable Inspector_Validatable => _validatable;

            [TextArea(5, 5)]
            [LabelText(nameof(Exception))]
            [ShowInInspector] string Inspector_Message => _exception.Message;
        }

        [LabelText(nameof(Entries))]
        [ListDrawerSettings(NumberOfItemsPerPage = 2, ShowFoldout = false)]
        [ShowInInspector] private IReadOnlyList<FailureEntry> Inspector_Entries
            => _entries;

        [Button("Validate")]
        private void Inspector_OnValidateButtonClicked()
        {
            _entries.Clear();

            var guids = AssetDatabase.FindAssets("t:ScriptableObject");
            var assets = ListPool<IValidatable>.New();

            foreach (string guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);

                if (asset is IValidatable validatable)
                {
                    assets.Add(validatable);
                }
            }
            foreach (var validatable in assets)
            {
                try
                {
                    validatable.Validate();
                }
                catch (ValidationException e)
                {
                    _entries.Add(new(validatable, e));
                }
            }
            assets.Clear();
            ListPool<IValidatable>.Free(assets);
        }
    }
}
#endif