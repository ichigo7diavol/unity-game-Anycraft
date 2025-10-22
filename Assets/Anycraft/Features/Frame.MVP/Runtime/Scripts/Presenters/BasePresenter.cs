using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using R3;
using UnityEngine;

namespace Anycraft.Features.Frame.MVP
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
            _modelObservable.AddTo(CtsToken);
        }
    }

    [UsedImplicitly]
    public abstract class BasePresenter
        : MonoBehaviour
    {
        public CancellationToken CtsToken => destroyCancellationToken;

        protected virtual void OnDestroy()
        {
        }
    }
}