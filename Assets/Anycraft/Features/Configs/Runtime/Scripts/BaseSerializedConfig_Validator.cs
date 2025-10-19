using FluentValidation;

namespace Anycraft.Features.Configs
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

        public abstract void Validate();
    }
}