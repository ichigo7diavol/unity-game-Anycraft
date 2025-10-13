using Anycraft.Features.Validation;
using UnityEngine;

namespace Anycraft.Features.Configs
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