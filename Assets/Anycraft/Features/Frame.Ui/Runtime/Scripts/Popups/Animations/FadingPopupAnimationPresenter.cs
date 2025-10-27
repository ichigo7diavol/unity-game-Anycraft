using JetBrains.Annotations;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using System.Threading;

namespace Anycraft.Features.Frame.Ui
{
    [UsedImplicitly]
    public sealed class FadingPopupAnimationPresenter
        : BasePopupAnimationPresenter
    {
        [Required]
        [SerializeField] private CanvasGroup _canvasGroup;

        [SerializeField] private float _duration;

        // todo: attach to token
        public async override UniTask ShowAsync(bool isInstant = false, CancellationToken token = default)
        {
            var elapsed = isInstant ? _duration : 0f;

            while (elapsed <= _duration && !token.IsCancellationRequested)
            {
                elapsed += Time.unscaledDeltaTime;
                _canvasGroup.alpha = Mathf.Clamp01(elapsed / _duration);

                await UniTask.NextFrame();
            }
        }

        // todo: attach to token
        public async override UniTask HideAsync(bool isInstant = false, CancellationToken token = default)
        {
            var elapsed = isInstant ? _duration : 0f;
            
            while (elapsed <= _duration && !token.IsCancellationRequested)
            {
                elapsed += Time.unscaledDeltaTime;
                _canvasGroup.alpha = 1.0f - Mathf.Clamp01(elapsed / _duration);

                await UniTask.NextFrame();
            }
        }
    }
}