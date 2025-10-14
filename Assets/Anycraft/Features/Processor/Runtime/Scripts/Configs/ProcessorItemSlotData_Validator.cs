using FluentValidation;

namespace Anycraft.Features.Processor.Configs
{
    public sealed partial class ProcessorItemSlotData
    {
        public sealed class Validator
            : AbstractValidator<ProcessorInputData>
        {
        }
    }
}

