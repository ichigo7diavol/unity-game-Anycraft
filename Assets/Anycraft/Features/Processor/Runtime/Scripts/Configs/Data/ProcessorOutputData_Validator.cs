using FluentValidation;

namespace Anycraft.Features.Processor
{
    public sealed partial class ProcessorOutputData
    {
        public sealed class Validator
            : AbstractValidator<ProcessorOutputData>
        {
        }
    }
}

