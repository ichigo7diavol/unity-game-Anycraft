using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Anycraft.Features.Frame.Ui
{
    [UsedImplicitly]
    public interface IPopupPresenter
    {
        UniTask ShowAsync(bool isInstant);
        UniTask HideAsync(bool isInstant);
    }
}