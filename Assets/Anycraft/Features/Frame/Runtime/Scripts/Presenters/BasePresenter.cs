using Anycraft.Features.Frame.Models;
using JetBrains.Annotations;
using UnityEngine;

namespace Anycraft.Features.Frame.Presenters
{
    [UsedImplicitly]
    public abstract class BasePresenter<TModel>
        : MonoBehaviour
        where TModel : BaseModel
    {
    }

    [UsedImplicitly]
    public abstract class BasePresenter
        : MonoBehaviour
    {
    }
}