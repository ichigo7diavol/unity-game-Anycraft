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
        : BaseModel
        where TModel : BaseModel
    {
        private readonly ObservableDictionary<int, BaseModel> _models = new();

        public IReadOnlyObservableDictionary<int, BaseModel> Models => _models;

        protected BaseCollectionModel()
        {
            _models.ObserveAdd().Subscribe(OnModelAdd).AddTo(CtsToken);
            _models.ObserveRemove().Subscribe(OnModelRemove).AddTo(CtsToken);
        }

        public TModel Create<T>()
            where T : TModel
        {
            var model = Factorize<T>();
            _models.Add(model.GetHashCode(), model);

            return model;
        }

        public override void Dispose()
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
            base.Dispose();
        }

        protected abstract TModel Factorize<T>()
            where T : TModel;
       
        protected virtual void OnModelAdd(
            CollectionAddEvent<KeyValuePair<int, BaseModel>> data)
        {
            data.Value.Value.CtsToken
                .Register(() => _models.Remove(data.Value.Key));
        }

        protected virtual void OnModelRemove(
            CollectionRemoveEvent<KeyValuePair<int, BaseModel>> data)
        {
        }
    }
}