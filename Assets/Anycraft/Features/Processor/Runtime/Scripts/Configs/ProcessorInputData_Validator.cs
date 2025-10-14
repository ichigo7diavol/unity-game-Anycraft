using FluentValidation;

namespace Anycraft.Features.Processor.Configs
{
    public sealed partial class ProcessorInputData
    {
        public sealed class Validator
            : AbstractValidator<ProcessorInputData>
        {
        }
    }
}

