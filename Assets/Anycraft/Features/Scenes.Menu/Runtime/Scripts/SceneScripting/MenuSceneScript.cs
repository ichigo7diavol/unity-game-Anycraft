using Anycraft.Features.Frame.Services.SceneScripting;
using Anycraft.Features.Frame.Ui;
using Anycraft.Features.Popups.MenuPopup;
using Cysharp.Threading.Tasks;
using MessagePipe;
using NUnit.Framework;

namespace Anycraft.Features.Scenes.SceneMenu
{
    public sealed class MenuSceneScript
        : BaseSceneScript, ISceneScriptStartable
    {
        private readonly IAsyncPublisher<ShowPopupEvent<MenuPopupPresenter>> _openMenuPopupPublisher;

        public MenuSceneScript
        (
            IAsyncPublisher<ShowPopupEvent<MenuPopupPresenter>> openMenuPopupPublisher
        )
        {
            Assert.IsNotNull(openMenuPopupPublisher);

            _openMenuPopupPublisher = openMenuPopupPublisher;
        }

        public async UniTask StartAsync()
        {
            await _openMenuPopupPublisher.PublishAsync(default);
        }
    }
}