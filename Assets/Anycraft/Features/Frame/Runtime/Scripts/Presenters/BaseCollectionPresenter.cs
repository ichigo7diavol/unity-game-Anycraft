using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ObservableCollections;
using R3;
using UnityEngine;

namespace Anycraft.Features.Frame.Presenters
{
    public abstract class BaseCollectionPresenter<TPresenter>
        : MonoBehaviour
        where TPresenter : BasePresenter
    {
        private readonly ObservableDictionary<string, TPresenter> _presenters = new();

        public IReadOnlyObservableDictionary<string, TPresenter> Presenters => _presenters;

        private void Awake()
        {
            _presenters.ObserveAdd().Subscribe(OnPresenterAdd)
                .AddTo(destroyCancellationToken);
            
            _presenters.ObserveRemove().Subscribe(OnPresenterRemove)
                .AddTo(destroyCancellationToken);
        }

        public abstract TPresenter Create();

        public void OnDestroy()
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
        }

        protected virtual void OnPresenterAdd(
            CollectionAddEvent<KeyValuePair<string, TPresenter>> data)
        {
            data.Value.Value.destroyCancellationToken
                .Register(() => _presenters.Remove(data.Value.Key));
        }

        protected virtual void OnPresenterRemove(
            CollectionRemoveEvent<KeyValuePair<string, TPresenter>> data)
        {
        }
    }
}