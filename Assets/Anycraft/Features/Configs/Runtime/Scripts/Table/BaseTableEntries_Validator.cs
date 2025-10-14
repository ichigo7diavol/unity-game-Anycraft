using FluentValidation;
using System.Linq;

namespace Anycraft.Features.Configs.Table
{
    public abstract partial class BaseTableEntries<TTable, TConfig> 
    {
        public sealed class Validator
            : AbstractValidator<BaseTableEntries<TTable, TConfig>>
        {
            public Validator()
            {
                RuleFor(x => x._ids)
                    .Must(list => list.Distinct().Count() == list.Count)
                    .WithMessage("Must contain unique values");
            }
        }
    }
}