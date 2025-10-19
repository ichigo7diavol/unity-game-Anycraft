using System.Threading;
using System.Xml.Serialization;
using Anycraft.Features.Frame.Models;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using R3;
using UnityEngine;

namespace Anycraft.Features.Frame.Presenters
{
    [UsedImplicitly]
    public abstract class BasePresenter<TModel>
        : BasePresenter
        where TModel : BaseModel
    {
        private readonly ReactiveProperty<TModel> _modelObservable = new();

        protected virtual void OnModelChanged(TModel model)
        {
        }

        private void Awake()
        {
            _modelObservable.Subscribe(OnModelChanged);
            _modelObservable.AddTo(Token);
        }
    }

    [UsedImplicitly]
    public abstract class BasePresenter
        : MonoBehaviour
    {
        public CancellationToken Token => destroyCancellationToken;

        protected virtual void OnDestroy()
        {
        }
    }
}