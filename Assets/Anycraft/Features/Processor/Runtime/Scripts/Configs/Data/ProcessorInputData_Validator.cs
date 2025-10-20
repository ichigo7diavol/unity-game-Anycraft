using FluentValidation;

namespace Anycraft.Features.Processor
{
    public sealed partial class ProcessorInputData
    {
        public sealed class Validator
            : AbstractValidator<ProcessorInputData>
        {
        }
    }
}

