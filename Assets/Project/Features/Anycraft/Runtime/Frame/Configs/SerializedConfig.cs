using UnityEngine;

namespace Anycraft.Frame.Configs
{
    public abstract partial class BaseSerializedConfig : ScriptableObject, IConfig
    {
        [HideInInspector]        
        [SerializeField] string _id;

        public string Id => _id;

        public virtual bool Validate(ref string errorMessage)
        {
            return true;
        }
    }
}