using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ObservableCollections;
using R3;
using UnityEngine;
using UnityEngine.Assertions;

namespace Anycraft.Features.Frame.Presenters
{
    public abstract class BaseCollectionPresenter<TPresenter>
        : BasePresenter
        where TPresenter : BasePresenter
    {
        private readonly ObservableDictionary<int, TPresenter> _presenters = new();

        public IReadOnlyObservableDictionary<int, TPresenter> Presenters => _presenters;

        private void Awake()
        {
            _presenters.ObserveAdd().Subscribe(OnPresenterAdd)
                .AddTo(CtsToken);
            
            _presenters.ObserveRemove().Subscribe(OnPresenterRemove)
                .AddTo(CtsToken);
        }

        public async UniTask<TPresenter> CreateAsync<T>(T prefab)
            where T : TPresenter
        {
            Assert.IsNotNull(prefab);
            
            var presenter = await FactorizeAsync<T>(prefab);
            _presenters.Add(presenter.GetHashCode(), presenter);

            return presenter;
        }

        protected override void OnDestroy()
        {
            foreach (var kvp in _presenters)
            {
                try
                {
                    Destroy(kvp.Value);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
            base.OnDestroy();
        }

        protected abstract UniTask<TPresenter> FactorizeAsync<T>(T prefab)
            where T : TPresenter;

        protected virtual void OnPresenterAdd(
            CollectionAddEvent<KeyValuePair<int, TPresenter>> data)
        {
            data.Value.Value.destroyCancellationToken
                .Register(() => _presenters.Remove(data.Value.Key));
        }

        protected virtual void OnPresenterRemove(
            CollectionRemoveEvent<KeyValuePair<int, TPresenter>> data)
        {
        }
    }
}