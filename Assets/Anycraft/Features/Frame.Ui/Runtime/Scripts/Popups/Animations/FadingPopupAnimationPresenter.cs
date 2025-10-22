using JetBrains.Annotations;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Anycraft.Features.Frame.Ui
{
    [UsedImplicitly]
    public sealed class FadingPopupAnimationPresenter
        : BasePopupAnimationPresenter
    {
        [Required]
        [SerializeField] private CanvasGroup _canvasGroup;

        [SerializeField] private float _duration;

        public async override UniTask ShowAsync()
        {
            var elapsed = 0f;

            while (elapsed < _duration)
            {
                elapsed += Time.unscaledDeltaTime;
                _canvasGroup.alpha = Mathf.Clamp01(elapsed / _duration);

                await UniTask.NextFrame();
            }
        }

        public async override UniTask HideAsync()
        {
            var elapsed = 0f;
            
            while (elapsed < _duration)
            {
                elapsed += Time.unscaledDeltaTime;
                _canvasGroup.alpha = 1.0f - Mathf.Clamp01(elapsed / _duration);

                await UniTask.NextFrame();
            }
        }
    }
}