using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.SceneScripting
{
    [UsedImplicitly]
    public abstract class BaseSceneScript : ScriptableObject
    {
        // public virtual async UniTask InitializeAsync() { }
        // public virtual async UniTask PostInitializeAsync() { }  
        
        public virtual async UniTask StartAsync() { }  
        // public virtual async UniTask PostStartAsync() { }  
    }
}