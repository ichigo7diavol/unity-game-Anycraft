using FluentValidation;

namespace Anycraft.Features.Processor
{
    public sealed partial class ProcessorItemSlotData
    {
        public sealed class Validator
            : AbstractValidator<ProcessorInputData>
        {
        }
    }
}

