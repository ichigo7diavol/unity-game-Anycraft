using R3;
using UnityEngine.Assertions;

namespace Anycraft.Features.SceneLoader
{
    public readonly struct SceneLoadingStartedEvent
    {
        public readonly ReadOnlyReactiveProperty<float> ProgressObservable;
        public readonly SceneReference SceneReference;

        public SceneLoadingStartedEvent
        (
            ReadOnlyReactiveProperty<float> progressObservable,
            SceneReference sceneReference
        )
        {
            Assert.IsNotNull(progressObservable);
            Assert.IsNotNull(sceneReference);

            ProgressObservable = progressObservable;
            SceneReference = sceneReference;
        }
    }

    public readonly struct SceneLoadingCompletedEvent
    {
        public readonly SceneReference SceneReference;

        public SceneLoadingCompletedEvent
        (
            SceneReference sceneReference
        )
        {
            Assert.IsNotNull(sceneReference);

            SceneReference = sceneReference;
        }
    }
}