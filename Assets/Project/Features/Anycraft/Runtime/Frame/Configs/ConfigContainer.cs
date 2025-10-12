using Anycraft.Utils;
using UnityEngine;

namespace Anycraft.Frame.Configs
{
    public abstract partial class ConfigContainer : ScriptableObject, IValidatable
    {
        [HideInInspector]
        [SerializeReference] private IConfig _config;
        
        public IConfig Config => _config;

        public virtual bool Validate(ref string errorMessage)
        {
            return _config.Validate(ref errorMessage);
        }
    }   
}