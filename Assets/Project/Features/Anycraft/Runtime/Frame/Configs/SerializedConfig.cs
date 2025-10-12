using Sirenix.OdinInspector;
using UnityEngine;

namespace Anycraft.Frame.Configs
{
    public abstract partial class BaseSerializedConfig : ScriptableObject, IConfig
    {
        [OnValueChanged(nameof(UpdateAssetName))]
        [SerializeField] string _id;

        public string Id => _id;

        public virtual bool Validate(ref string errorMessage)
        {
            return true;
        }

        partial void UpdateAssetName();
    }
}