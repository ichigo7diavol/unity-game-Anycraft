using JetBrains.Annotations;
using Cysharp.Threading.Tasks;
using Anycraft.Features.Frame.MVP;
using System.Threading;

namespace Anycraft.Features.Frame.Ui
{
    [UsedImplicitly]
    public abstract class BasePopupAnimationPresenter
        : BasePresenter
    {
        public virtual UniTask ShowAsync(bool isInstant = false, CancellationToken token = default) => UniTask.CompletedTask;
        public virtual UniTask HideAsync(bool isInstant = false, CancellationToken token = default) => UniTask.CompletedTask;
    }
}