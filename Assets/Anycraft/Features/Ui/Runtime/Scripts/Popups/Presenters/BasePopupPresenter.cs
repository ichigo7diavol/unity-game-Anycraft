using Anycraft.Features.Frame.Presenters;
using Cysharp.Threading.Tasks;
using R3;
using JetBrains.Annotations;

namespace Anycraft.Features.Ui.Popups.Presenters
{
    [UsedImplicitly]
    public abstract class BasePopupPresenter<TData>
        : BasePopupPresenter
    {
        private readonly ReactiveProperty<TData> _dataObservable = new();

        public TData Data
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

    public abstract class BasePopupPresenter
        : BasePresenter
    {
        public virtual UniTask ShowAsync() { return UniTask.CompletedTask; }
        public virtual UniTask HideAsync() { return UniTask.CompletedTask; }
    }
}