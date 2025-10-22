using R3;
using UnityEngine.Assertions;

namespace Anycraft.Features.Frame.Services.SceneLoader
{
    public readonly struct SceneLoadingStartedEvent
    {
        public readonly string LoadingPopupHeaderText;
        public readonly ReadOnlyReactiveProperty<string> LoadingPopupBottomTextxObservable;

        public readonly ReadOnlyReactiveProperty<float> ProgressObservable;
        public readonly SceneReference SceneReference;

        public SceneLoadingStartedEvent
        (
            string loadingPopupHeaderText,
            ReadOnlyReactiveProperty<string> loadingPopupBottomTextxObservable,
            ReadOnlyReactiveProperty<float> progressObservable,
            SceneReference sceneReference
        )
        {
            Assert.IsFalse(string.IsNullOrEmpty(loadingPopupHeaderText));
            Assert.IsNotNull(loadingPopupBottomTextxObservable);
            Assert.IsNotNull(progressObservable);
            Assert.IsNotNull(sceneReference);

            LoadingPopupHeaderText = loadingPopupHeaderText;
            LoadingPopupBottomTextxObservable = loadingPopupBottomTextxObservable;
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