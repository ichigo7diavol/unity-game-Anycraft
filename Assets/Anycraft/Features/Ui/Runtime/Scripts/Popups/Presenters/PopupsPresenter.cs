using Anycraft.Features.Frame.Presenters;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions;
using VContainer;
using VContainer.Unity;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Ui.Popups.Presenters
{
    [UsedImplicitly]
    public sealed class PopupsPresenter
        : BaseCollectionPresenter<BasePopupPresenter>
    {
        private IObjectResolver _resolver;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            Assert.IsNotNull(resolver);

            _resolver = resolver;
        }

        protected override UniTask<BasePopupPresenter> FactorizeAsync<T>(T prefab)
        {
            Assert.IsNotNull(prefab);

            var presenter = _resolver.Instantiate(prefab, (RectTransform)transform, false);

            return UniTask.FromResult<BasePopupPresenter>(presenter);
        }
    }
}