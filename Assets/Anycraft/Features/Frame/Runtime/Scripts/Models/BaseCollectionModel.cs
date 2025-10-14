using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using ObservableCollections;
using R3;
using UnityEngine;

namespace Anycraft.Features.Frame.Models
{
    public abstract class BaseCollectionModel<TModel> 
        : IDisposable
        where TModel : BaseModel
    {
        private readonly CancellationTokenSource _cts = new();
        private readonly ObservableDictionary<string, BaseModel> _models = new();

        public CancellationToken Token => _cts.Token;

        public IReadOnlyObservableDictionary<string, BaseModel> Models => _models;

        protected BaseCollectionModel()
        {
            _models.ObserveAdd().Subscribe(OnModelAdd).AddTo(Token);
            _models.ObserveRemove().Subscribe(OnModelRemove).AddTo(Token);
        }

        public abstract TModel Create();

        public void Dispose()
        {
            foreach (var kvp in _models)
            {
                try
                {
                    kvp.Value.Dispose();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
            _cts.Cancel();
            _cts.Dispose();
        }

        protected virtual void OnModelAdd(
            CollectionAddEvent<KeyValuePair<string, BaseModel>> data)
        {
            data.Value.Value.Token
                .Register(() => _models.Remove(data.Value.Key));
        }

        protected virtual void OnModelRemove(
            CollectionRemoveEvent<KeyValuePair<string, BaseModel>> data)
        {
        }
    }
}