using FluentValidation;

namespace Anycraft.Features.Processor.Configs
{
    public sealed partial class ProcessorOutputData
    {
        public sealed class Validator
            : AbstractValidator<ProcessorOutputData>
        {
        }
    }
}

