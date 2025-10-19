using System.Collections.Generic;
using System;
using Sirenix.OdinInspector;
using Anycraft.Features.Ui.Popups.Presenters;

namespace Anycraft.Features.Ui.Popups.Services
{
    public sealed partial class PopupsService
    {
        [ShowInInspector] private IReadOnlyDictionary<Type, BasePopupPresenter> Inspector_Prefabs
            => _prefabs;

        [ShowInInspector] private IReadOnlyDictionary<Type, BasePopupPresenter> Inspector_Pressenters
            => _popups;
        
        [ShowInInspector] private PopupsPresenter Inspector_PopupsPresenter 
            => _presenter;
    }
}