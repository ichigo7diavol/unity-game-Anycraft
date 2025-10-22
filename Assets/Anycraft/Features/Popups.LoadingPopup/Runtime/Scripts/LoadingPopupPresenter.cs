using Anycraft.Features.Frame.Ui;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Anycraft.Features.Popups.LoadingPopup
{
    [UsedImplicitly]
    public sealed class LoadingPopupPresenter
        : BasePopupPresenter<LoadingPopupPresenter.Data>
    {
        [UsedImplicitly]
        public sealed class Data
        {
            public readonly ReadOnlyReactiveProperty<float> ProgressObservable;

            public Data(ReadOnlyReactiveProperty<float> progressObservable)
            {
                Assert.IsNotNull(progressObservable);

                ProgressObservable = progressObservable;
            }
        }
    
        [SerializeField] private Slider _progressSlider;

        protected override void OnDataChanged(Data data)
        {
            base.OnDataChanged(data);

            if (data == null)
            {
                return;
            }
            data.ProgressObservable
                .Subscribe(this, (value, state) => state._progressSlider.value = value)
                .AddTo(DataCtsToken);
        }
    }
}