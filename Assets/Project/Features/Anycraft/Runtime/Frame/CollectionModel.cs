using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ObservableCollections;
using R3;
using UnityEngine;
using Anycraft.Frame.Configs;

namespace Anycraft.Frame
{
    public abstract class BaseCollectionModel<TModel, TConfig> : IDisposable
        where TModel : BaseModel<TConfig>
        where TConfig : IConfig
    {
        private readonly CancellationTokenSource _cts = new();

        private readonly ObservableList<BaseModel<TConfig>> _models = new();

        public CancellationToken Token => _cts.Token;

        public IReadOnlyObservableList<BaseModel<TConfig>> Models => _models;

        public BaseCollectionModel()
        {
            _models.ObserveAdd().Subscribe(OnModelAdd).AddTo(Token);
            _models.ObserveRemove().Subscribe(OnModelRemove).AddTo(Token);
            _models.ObserveChanged().Subscribe(OnModelChanged).AddTo(Token);
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        private void OnModelAdd(CollectionAddEvent<BaseModel<TConfig>> data)
        {
        }

        private void OnModelRemove(CollectionRemoveEvent<BaseModel<TConfig>> data)
        {
        }

        private void OnModelChanged(CollectionChangedEvent<BaseModel<TConfig>> data)
        {
        }
    }
}