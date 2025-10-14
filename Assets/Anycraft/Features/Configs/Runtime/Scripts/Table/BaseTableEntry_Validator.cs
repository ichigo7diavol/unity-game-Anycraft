using Anycraft.Features.Validation;
using FluentValidation;

namespace Anycraft.Features.Configs.Table
{
    public partial class BaseTableEntry<TTable, TConfig>
    {
        public sealed class Validator
            : AbstractValidator<BaseTableEntry<TTable, TConfig>>
        {
            public Validator()
            {
                RuleFor(c => c._id)
                    .NotNull()
                    .NotEmpty();

                RuleFor(c => c)
                    .NotNull();
            }
        }

        public void Validate()
        {
            this.ValidateAndThrow
            <
                Validator,
                BaseTableEntry<TTable, TConfig>
            >();
        }
    }
}