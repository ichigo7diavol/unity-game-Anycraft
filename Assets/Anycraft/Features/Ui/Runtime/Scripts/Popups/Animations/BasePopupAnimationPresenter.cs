using Anycraft.Features.Frame.Presenters;
using JetBrains.Annotations;
using Cysharp.Threading.Tasks;

namespace Anycraft.Features.Ui
{
    [UsedImplicitly]
    public abstract class BasePopupAnimationPresenter
        : BasePresenter
    {
        public virtual UniTask ShowAsync() => UniTask.CompletedTask;
        public virtual UniTask HideAsync() => UniTask.CompletedTask;
    }
}