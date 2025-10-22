using Cysharp.Threading.Tasks;
using UnityEngine.Assertions;
using VContainer;
using VContainer.Unity;
using JetBrains.Annotations;
using UnityEngine;
using Anycraft.Features.Frame.MVP;

namespace Anycraft.Features.Frame.Ui
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

            var presenter = _resolver.Instantiate(prefab, GetComponent<RectTransform>(), false);

            return UniTask.FromResult<BasePopupPresenter>(presenter);
        }
    }
}