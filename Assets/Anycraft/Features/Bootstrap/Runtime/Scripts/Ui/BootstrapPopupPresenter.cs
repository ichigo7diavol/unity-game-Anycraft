
using Anycraft.Features.Ui.Popups.Presenters;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using R3;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Anycraft.Features.Bootstrap.Ui
{
    [UsedImplicitly]
    public sealed class BootstrapPopupPresenter
        : BasePopupPresenter<BootstrapPopupPresenter.Data>
    {
        public readonly struct Data
        {
            public readonly ReadOnlyReactiveProperty<float> ProgressObservable;

            public Data(ReactiveProperty<float> progressObservable)
            {
                ProgressObservable = progressObservable;
            }
        }

        [Required]
        [SerializeField] private Slider _progressSlider;

        protected override void OnDataChanged(Data data)
        {
            data.ProgressObservable
                .Subscribe(this, (value, state) => state._progressSlider.value = value)
                .AddTo(Token);
        }
    } 
}