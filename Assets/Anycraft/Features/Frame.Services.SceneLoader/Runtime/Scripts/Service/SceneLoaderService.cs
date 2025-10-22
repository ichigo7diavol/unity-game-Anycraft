using System;
using System.Threading;
using Anycraft.Features.Extenions.VContainer;
using Anycraft.Features.Frame.Logger;
using Anycraft.Features.Frame.Services.SceneScripting;
using Anycraft.Features.Services;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using VContainer;

namespace Anycraft.Features.Frame.Services.SceneLoader
{
    [UsedImplicitly]
    public sealed class SceneLoaderService
        : IService
    {
        private class ProgressHandler
            : IProgress<float>
        {
            private readonly SceneLoaderService _service;

            public ProgressHandler(SceneLoaderService service)
            {
                _service = service;
            }

            public void Report(float value)
            {
                _service.Progress = value;
            }
        }

        private readonly CancellationTokenSource _cts = new();
        private readonly ProgressHandler _progressHandler;

        private readonly ReactiveProperty<float> _progressObservable = new();
        private readonly ReactiveProperty<bool> _isLoadingObservable = new();

        private readonly IPublisher<SceneLoadingStartedEvent> _sceneLoadingStartedEventPublisher;
        private readonly IPublisher<SceneLoadingCompletedEvent> _sceneLoadingCompletedEventPublisher;

        public ReadOnlyReactiveProperty<float> ProgressObservable => _progressObservable;
        public float Progress
        {
            get => _progressObservable.Value;
            set => _progressObservable.Value = value;
        }

        public ReadOnlyReactiveProperty<bool> IsLoadingObservable => _isLoadingObservable;
        public bool IsLoading
        {
            get => _isLoadingObservable.Value;
            set => _isLoadingObservable.Value = value;
        }

        public CancellationToken Token => _cts.Token;

        public SceneLoaderService
        (
            IPublisher<SceneLoadingStartedEvent> sceneLoadingStartedEventPublisher,
            IPublisher<SceneLoadingCompletedEvent> sceneLoadingCompletedEventPublisher
        )
        {
            Assert.IsNotNull(sceneLoadingStartedEventPublisher);
            Assert.IsNotNull(sceneLoadingCompletedEventPublisher);

            _sceneLoadingStartedEventPublisher = sceneLoadingStartedEventPublisher;
            _sceneLoadingCompletedEventPublisher = sceneLoadingCompletedEventPublisher;

            _progressHandler = new ProgressHandler(this);

            _progressObservable.AddTo(Token);
            _isLoadingObservable.AddTo(Token);
        }

        public async UniTask LoadSceneAndRunScriptAsync<TSceneScript>(SceneReference sceneReference)
            where TSceneScript : ISceneScript, ISceneScriptStartable
        {
            Assert.IsNotNull(sceneReference);
            Assert.IsFalse(IsLoading);

            await LoadSceneAsync_Internal(sceneReference, LoadSceneMode.Additive);

            try
            {
                var script = GetSceneScript<TSceneScript>();
                script.StartAsync().Forget();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public async UniTask LoadSceneAndRunScriptAsync<TSceneScript, TScriptData>(
            SceneReference sceneReference, TScriptData data)
            where TSceneScript : ISceneScript, ISceneScriptStartable<TScriptData>
        {
            Assert.IsNotNull(sceneReference);
            Assert.IsFalse(IsLoading);

            await LoadSceneAsync_Internal(sceneReference, LoadSceneMode.Single);

            try
            {
                var script = GetSceneScript<TSceneScript>();
                script.StartAsync(data).Forget();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private async UniTask LoadSceneAsync_Internal
        (
            SceneReference sceneReference,
            LoadSceneMode loadSceneMode
        )
        {
            Assert.IsNotNull(sceneReference);

            IsLoading = true;

            this.LogStepStarted($"Scene: '{sceneReference.Path}' loading");

            RaiseSceneLoadingStarted(sceneReference);

            var operation = SceneManager.LoadSceneAsync(sceneReference.BuildIndex, loadSceneMode);
            await operation.ToUniTask(progress: _progressHandler);

            this.LogStepCompleted($"Scene: '{sceneReference.Path}' loading");

            RaiseSceneLoadingCompleted(sceneReference);

            IsLoading = false;
        }

        private TSceneScript GetSceneScript<TSceneScript>()
            where TSceneScript : ISceneScript
        {
            var lifetimeScope = UnityEngine.Object.FindFirstObjectByType<BaseLifetimeScope>();
            return lifetimeScope.Container.Resolve<TSceneScript>();
        }

        private void RaiseSceneLoadingStarted(SceneReference sceneReference)
        {
            _sceneLoadingStartedEventPublisher.Publish(new SceneLoadingStartedEvent(
                _progressObservable,
                sceneReference
            ));
        }
        
        private void RaiseSceneLoadingCompleted(SceneReference sceneReference)
        {
            _sceneLoadingCompletedEventPublisher.Publish(new SceneLoadingCompletedEvent(
                sceneReference
            ));
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }
    }
}