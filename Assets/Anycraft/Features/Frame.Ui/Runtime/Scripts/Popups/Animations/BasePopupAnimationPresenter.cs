using JetBrains.Annotations;
using Cysharp.Threading.Tasks;
using Anycraft.Features.Frame.MVP;

namespace Anycraft.Features.Frame.Ui
{
    [UsedImplicitly]
    public abstract class BasePopupAnimationPresenter
        : BasePresenter
    {
        public virtual UniTask ShowAsync() => UniTask.CompletedTask;
        public virtual UniTask HideAsync() => UniTask.CompletedTask;
    }
}