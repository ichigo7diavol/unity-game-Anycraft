using System.Collections.Generic;
using System;
using Sirenix.OdinInspector;

namespace Anycraft.Features.Frame.Ui
{
    public sealed partial class PopupsService
    {
        [HideDuplicateReferenceBox]
        [LabelText(nameof(_prefabs))]
        [ShowInInspector] private IReadOnlyDictionary<Type, BasePopupPresenter> Inspector_Prefabs
            => _prefabs;

        [HideDuplicateReferenceBox]
        [LabelText(nameof(_popups))]
        [ShowInInspector] private IReadOnlyDictionary<Type, BasePopupPresenter> Inspector_Popups
            => _popups;
        
        [HideDuplicateReferenceBox]
        [LabelText(nameof(_presenter))]
        [ShowInInspector] private PopupsPresenter Inspector_Presenter 
            => _presenter;
    }
}