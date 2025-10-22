using Anycraft.Features.Frame.Ui;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using R3;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Anycraft.Features.Popups.BootstrapPopup
{
    
    [UsedImplicitly]
    public sealed class BootstrapPopupPresenter
        : BasePopupPresenter<BootstrapPopupPresenter.Data>
    {
        public sealed class Data
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