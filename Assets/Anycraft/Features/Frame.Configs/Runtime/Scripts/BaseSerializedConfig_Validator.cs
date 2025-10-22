using FluentValidation;

namespace Anycraft.Features.Frame.Configs
{
    public abstract partial class BaseSerializedConfig
    {
        public sealed class Validator
            : AbstractValidator<BaseSerializedConfig>
        {
            public Validator()
            {
            }
        }

        public virtual void Validate() { }
    }
}