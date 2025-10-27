using Cysharp.Threading.Tasks;
using R3;
using JetBrains.Annotations;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Threading;
using Anycraft.Features.Frame.MVP;
using Sirenix.Utilities.Editor.Expressions;

namespace Anycraft.Features.Frame.Ui
{
    [UsedImplicitly]
    public abstract class BasePopupPresenter<TData>
        : BasePopupPresenter
        where TData : class
    {
        private readonly ReactiveProperty<TData> _dataObservable = new();

        private CancellationTokenSource _dataCts;

        public CancellationToken DataCtsToken => _dataCts.Token;

        public TData PopupData
        {
            get => _dataObservable.Value;
            set => _dataObservable.Value = value;
        }

        protected virtual void OnDataChanged(TData data)
        {
            _dataCts?.Cancel();
            _dataCts?.Dispose();

            if (data == null)
            {
                return;
            }
            _dataCts = new();
        }

        protected void Awake()
        {
            _dataObservable.Subscribe(OnDataChanged);
            _dataObservable.AddTo(CtsToken);
        }

        protected void Oestroy()
        {
            _dataCts?.Cancel();
            _dataCts?.Dispose();
        }
    }

    [UsedImplicitly]
    public abstract class BasePopupPresenter
        : BasePresenter, IPopupPresenter
    {
        [Required]
        [SerializeField] BasePopupAnimationPresenter _animationPresenter;

        public virtual async UniTask ShowAsync(bool isInstant = false) 
            => await _animationPresenter.ShowAsync(isInstant, token: CtsToken);

        public virtual async UniTask HideAsync(bool isInstant = false)
        {
            await _animationPresenter.HideAsync(isInstant, token: CtsToken);
            // todo: do something
            Destroy(gameObject);
        }
    }
}