using Anycraft.Features.Frame.Ui;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using R3;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Anycraft.Features.Popups.LoadingPopup
{
    [UsedImplicitly]
    public sealed class LoadingPopupPresenter
        : BasePopupPresenter<LoadingPopupPresenter.Data>
    {
        public sealed class Data
        {
            public readonly string HeaderText;
            public readonly ReadOnlyReactiveProperty<string> BottomTextObservable;
            public readonly ReadOnlyReactiveProperty<float> ProgressObservable;

            public Data
            (
                string headerText,
                ReadOnlyReactiveProperty<string> bottomTextObservable,
                ReadOnlyReactiveProperty<float> progressObservable
            )
            {
                HeaderText = headerText;
                ProgressObservable = progressObservable;
                BottomTextObservable = bottomTextObservable;
            }
        }

        [Required] [SerializeField] private TextMeshProUGUI _header;
        [Required] [SerializeField] private TextMeshProUGUI _bottomText;
        [Required] [SerializeField] private Slider _progressSlider;

        protected override void OnDataChanged(Data data)
        {
            base.OnDataChanged(data);

            if (data == null)
            {
                return;
            }
            _header.text = data.HeaderText;

            data.BottomTextObservable
                .Subscribe(this, (value, state) => state._bottomText.text = value)
                .AddTo(DataCtsToken);

            data.ProgressObservable
                .Subscribe(this, (value, state) => state._progressSlider.value = value)
                .AddTo(DataCtsToken);
        }
    } 
}