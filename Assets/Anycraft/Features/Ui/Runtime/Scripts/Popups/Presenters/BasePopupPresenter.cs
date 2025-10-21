using Anycraft.Features.Frame.Presenters;
using Cysharp.Threading.Tasks;
using R3;
using JetBrains.Annotations;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Anycraft.Features.Ui
{
    [UsedImplicitly]
    public abstract class BasePopupPresenter<TData>
        : BasePopupPresenter
    {
        private readonly ReactiveProperty<TData> _dataObservable = new();

        public TData PopupData
        {
            get => _dataObservable.Value;
            set => _dataObservable.Value = value;
        }

        protected virtual void OnDataChanged(TData data)
        {
        }

        private void Awake()
        {
            _dataObservable.Subscribe(OnDataChanged);
            _dataObservable.AddTo(Token);
        }
    }

    [UsedImplicitly]
    public abstract class BasePopupPresenter
        : BasePresenter, IPopupPresenter
    {
        [Required]
        [SerializeField] BasePopupAnimationPresenter _animationPresenter;

        public virtual async UniTask ShowAsync() 
            => await _animationPresenter.ShowAsync();

        public virtual async UniTask HideAsync() 
            => await _animationPresenter.HideAsync();
    }
}