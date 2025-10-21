using Anycraft.Features.Ui;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;


namespace Anycraft.Features.Global
{
    [UsedImplicitly]
    public readonly struct LoadingPopupData
    {
        public readonly ReadOnlyReactiveProperty<float> ProgressObservable;

        public LoadingPopupData(ReadOnlyReactiveProperty<float> progressObservable)
        {
            Assert.IsNotNull(progressObservable);

            ProgressObservable = progressObservable;
        }
    }
    
    [UsedImplicitly]
    public sealed class LoadingPopupPresenter
        : BasePopupPresenter<LoadingPopupData>
    {
        [SerializeField] private Slider _progressSlider;

        protected override void OnDataChanged(LoadingPopupData data)
        {
            base.OnDataChanged(data);

            data.ProgressObservable
                .Subscribe(this, (value, state) => state._progressSlider.value = value)
                .AddTo(Token);
        }
    }
}