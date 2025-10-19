using Anycraft.Features.Services;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions;
using UnityEngine;
using JetBrains.Annotations;
using System.Collections.Generic;
using System;
using System.Linq;
using Anycraft.Features.Ui.Popups.Presenters;
using MessagePipe;
using System.Threading;

namespace Anycraft.Features.Ui.Popups.Services
{
    [UsedImplicitly]
    public sealed partial class PopupsService
        : IService
    {
        private readonly CancellationTokenSource _cts = new();

        private readonly IReadOnlyDictionary<Type, BasePopupPresenter> _prefabs;
        private readonly Dictionary<Type, BasePopupPresenter> _popups = new();
        private readonly PopupsPresenter _presenter;

        public CancellationToken Token => _cts.Token;

        public PopupsService
        (
            PopupsPresenter presenter,
            IReadOnlyList<BasePopupPresenter> prefabs
        )
        {
            Assert.IsNotNull(presenter);
            Assert.IsNotNull(prefabs);

            _presenter = presenter;
            _prefabs = prefabs.ToDictionary(p => p.GetType());
        }

        public async UniTask<TPrenter> ShowAsync<TPrenter>()
            where TPrenter : BasePopupPresenter
        {
            Debug.Log($"Opening: {typeof(TPrenter).GetType().Name}");

            var type = typeof(TPrenter);

            if (_popups.ContainsKey(type))
            {
                throw new InvalidOperationException();
            }
            var prefab = GetPrefab<TPrenter>();
            var presenter = await _presenter.CreateAsync(prefab);

            presenter.Token.Register(() => _popups.Remove(type));
            _popups.Add(type, presenter);

            try
            {
                await presenter.ShowAsync();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return (TPrenter)presenter;
        }

        public async UniTask HideAsync<TPrenter>()
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
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            GameObject.Destroy(presenter);
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