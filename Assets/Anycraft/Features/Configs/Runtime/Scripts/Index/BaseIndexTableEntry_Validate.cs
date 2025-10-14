using FluentValidation;

namespace Anycraft.Features.Configs.Index
{
    public partial class BaseIndexTableEntry<TTable, TConfig>
    {
        public sealed class Validator
            : AbstractValidator<BaseIndexTableEntry<TTable, TConfig>>
        {
            public Validator()
            {
            }
        }
    }
}