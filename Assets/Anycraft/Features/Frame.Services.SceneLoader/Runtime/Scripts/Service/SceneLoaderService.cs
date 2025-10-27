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
using VContainer.Unity;

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

        private readonly ReactiveProperty<string> _loadingScreenBottomTextObservable = new("BOTTOM TEXT");
        private readonly ReactiveProperty<float> _progressObservable = new();
        private readonly ReactiveProperty<bool> _isLoadingObservable = new();

        private readonly IAsyncPublisher<SceneLoadingStartedEvent> _sceneLoadingStartedEventPublisher;
        private readonly IAsyncPublisher<SceneLoadingCompletedEvent> _sceneLoadingCompletedEventPublisher;

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
            IAsyncPublisher<SceneLoadingStartedEvent> sceneLoadingStartedEventPublisher,
            IAsyncPublisher<SceneLoadingCompletedEvent> sceneLoadingCompletedEventPublisher
        )
        {
            Assert.IsNotNull(sceneLoadingStartedEventPublisher);
            Assert.IsNotNull(sceneLoadingCompletedEventPublisher);

            _sceneLoadingStartedEventPublisher = sceneLoadingStartedEventPublisher;
            _sceneLoadingCompletedEventPublisher = sceneLoadingCompletedEventPublisher;

            _progressHandler = new ProgressHandler(this);

            _loadingScreenBottomTextObservable.AddTo(Token);
            _progressObservable.AddTo(Token);
            _isLoadingObservable.AddTo(Token);
        }

        public async UniTask LoadSceneAndRunScriptAsync<TLifetimeScope, TSceneScript>(SceneReference sceneReference)
            where TLifetimeScope : BaseLifetimeScope
            where TSceneScript : ISceneScriptBuildable
        {
            Assert.IsNotNull(sceneReference);
            Assert.IsFalse(IsLoading);

            try
            {
                await LoadSceneAsync_Internal(sceneReference, LoadSceneMode.Single);

                var script = GetSceneScript<TLifetimeScope, TSceneScript>();
                await script.BuildAsync();
                await script.StartAsync();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public async UniTask LoadSceneAndRunScriptAsync<TLifetimeScope, TSceneScript, TScriptData>(
            SceneReference sceneReference, TScriptData data)
            where TLifetimeScope : BaseLifetimeScope
            where TSceneScript : ISceneScriptBuildable<TScriptData>
        {
            Assert.IsNotNull(sceneReference);
            Assert.IsFalse(IsLoading);

            try
            {
                await LoadSceneAsync_Internal(sceneReference, LoadSceneMode.Single);

                var script = GetSceneScript<TLifetimeScope, TSceneScript>();
                await script.BuildAsync(data);
                await script.StartAsync();
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
            Assert.IsFalse(IsLoading);

            IsLoading = true;

            this.LogStepStarted($"Scene: '{sceneReference.Path}' loading");

            await RaiseSceneLoadingStarted(sceneReference);

            var operation = SceneManager.LoadSceneAsync(sceneReference.BuildIndex, loadSceneMode);
            // todo: exception at exit from app while loading scene 
            await operation.ToUniTask(progress: _progressHandler);

            this.LogStepCompleted($"Scene: '{sceneReference.Path}' loading");

            await RaiseSceneLoadingCompleted(sceneReference);

            IsLoading = false;
        }

        private TSceneScript GetSceneScript<TLifetimeScope, TSceneScript>()
            where TLifetimeScope : BaseLifetimeScope
            where TSceneScript : ISceneScript
        {
            var lifetimeScope = UnityEngine.Object.FindFirstObjectByType<TLifetimeScope>();
            return lifetimeScope.Container.Resolve<TSceneScript>();
        }

        private async UniTask RaiseSceneLoadingStarted(SceneReference sceneReference)
        {
            // todo: decouple ui things
            // maybe some scene loading data with loaded scene abstract context
            var data = new SceneLoadingStartedEvent(
                "Scene loading",
                _loadingScreenBottomTextObservable,
                _progressObservable,
                sceneReference
            );
            try
            {
                await _sceneLoadingStartedEventPublisher.PublishAsync(data);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        
        private async UniTask RaiseSceneLoadingCompleted(SceneReference sceneReference)
        {
            var data = new SceneLoadingCompletedEvent(
                sceneReference
            );
            try
            {
                await _sceneLoadingCompletedEventPublisher.PublishAsync(data);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }
    }
}