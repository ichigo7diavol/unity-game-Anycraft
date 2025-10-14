using FluentValidation;

namespace Anycraft.FluentValidationExtensions.Configs.Table
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
            }
        }
    }
}