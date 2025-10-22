using Anycraft.Features.Services;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions;
using UnityEngine;
using JetBrains.Annotations;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using Anycraft.Features.Logger;

namespace Anycraft.Features.Ui
{
    [UsedImplicitly]
    public sealed partial class PopupsService
        : IService
    {
        private readonly CancellationTokenSource _cts = new();
        private readonly PopupsServiceConfig _config;

        private readonly IReadOnlyDictionary<Type, BasePopupPresenter> _prefabs;
        private readonly Dictionary<Type, BasePopupPresenter> _popups = new();
        private readonly PopupsPresenter _presenter;

        public CancellationToken Token => _cts.Token;

        public PopupsService
        (
            PopupsServiceConfig config,
            PopupsPresenter presenter,
            IEnumerable<BasePopupPresenter> prefabs
        )
        {
            Assert.IsNotNull(config);
            Assert.IsNotNull(presenter);

            _presenter = presenter;
            _config = config;

            _prefabs = prefabs.ToDictionary(p => p.GetType());
        }
        
        public async UniTask<TPopupPresenter> ShowPopupAsync<TPopupPresenter, TPopupData>(TPopupData data)
            where TPopupPresenter : BasePopupPresenter<TPopupData>
            where TPopupData : class
        {
            this.LogStepStarted($"Opening: {typeof(TPopupPresenter).Name}");
            try
            {
                var presenter = await CreatePresenter<TPopupPresenter>();
                presenter.PopupData = data;

                await presenter.ShowAsync();

                this.LogStepCompleted($"Opening: {typeof(TPopupPresenter).Name}");
    
                return presenter;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        public async UniTask<TPopupPresenter> ShowPopupAsync<TPopupPresenter>()
            where TPopupPresenter : BasePopupPresenter
        {
            this.LogStepStarted($"Opening: {typeof(TPopupPresenter).Name}");
            try
            {
                var presenter = await CreatePresenter<TPopupPresenter>();
                await presenter.ShowAsync();

                this.LogStepCompleted($"Opening: {typeof(TPopupPresenter).Name}");
    
                return presenter;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        public async UniTask HidePopupAsync<TPrenter>()
            where TPrenter : BasePopupPresenter
        {
            var type = typeof(TPrenter);

            if (!_popups.Remove(type, out var presenter))
            {
                throw new InvalidOperationException();
            }
            try
            {
                await presenter.HideAsync();
                GameObject.Destroy(presenter);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private async UniTask<TPopupPresenter> CreatePresenter<TPopupPresenter>()
            where TPopupPresenter : BasePopupPresenter
        {
            this.LogStepStarted($"Creating: {typeof(TPopupPresenter).Name}");

            var type = typeof(TPopupPresenter);

            if (_popups.TryGetValue(type, out var presenter))
            {
                return (TPopupPresenter)presenter;
            }
            var prefab = GetPrefab<TPopupPresenter>();
            presenter = await _presenter.CreateAsync(prefab);

            presenter.CtsToken.Register(() => _popups.Remove(type));
            _popups.Add(type, presenter);

            this.LogStepCompleted($"Creating: {typeof(TPopupPresenter).Name}");

            return (TPopupPresenter)presenter;
        }

        private T GetPrefab<T>()
            where T : BasePopupPresenter
        {
            if (!_prefabs.TryGetValue(typeof(T), out var prefab))
            {
                throw new InvalidOperationException();
            }
            return (T)prefab;
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }
    }
}