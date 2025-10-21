using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Anycraft.Features.Ui
{
    [UsedImplicitly]
    public interface IPopupPresenter
    {
        UniTask ShowAsync();
        UniTask HideAsync();
    }
}