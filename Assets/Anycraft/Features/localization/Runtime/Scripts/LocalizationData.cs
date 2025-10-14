using System;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Localization
{
    [Serializable]
    public abstract class BaseLocalizationData
    {
        [SerializeField] private string _debugName = "DebugName";

        public string DebugName { get => _debugName; }
    } 
}