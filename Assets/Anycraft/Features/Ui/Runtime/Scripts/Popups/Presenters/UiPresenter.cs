using Anycraft.Features.Frame.Presenters;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Anycraft.Features.Ui
{

    [UsedImplicitly]
    public sealed class UiPresenter
        : BasePresenter
    {
        [Required]
        [SerializeField] private PopupsPresenter _popupsPresenter;
    }
}