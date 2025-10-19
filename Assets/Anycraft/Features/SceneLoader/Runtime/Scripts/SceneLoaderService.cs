using Anycraft.Features.Services;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace Anycraft.Features.SceneLoader
{
    [UsedImplicitly]
    public sealed class SceneLoaderService
        : IService
    {
        public SceneLoaderService()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public UniTask LoadScene(SceneReference sceneReference)
        {
            Assert.IsNotNull(sceneReference);

            return UniTask.CompletedTask;
        }

        public void Dispose()
        {
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
        }
    }
}