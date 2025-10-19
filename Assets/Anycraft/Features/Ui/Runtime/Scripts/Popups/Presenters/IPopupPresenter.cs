using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Anycraft.Features.Ui.Popups.Presenters
{
    [UsedImplicitly]
    public interface IPopupPresenter
    {
        UniTask ShowAsync();
        UniTask HideAsync();
    }
}