using Anycraft.Features.Frame.MVP;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Anycraft.Features.Frame.Ui
{
    [UsedImplicitly]
    public sealed class UiPresenter
        : BasePresenter
    {
        [Required]
        [SerializeField] private PopupsPresenter _popupsPresenter;
    }
}