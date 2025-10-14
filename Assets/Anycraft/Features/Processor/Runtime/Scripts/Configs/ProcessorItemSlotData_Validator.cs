using FluentValidation;

namespace Anycraft.FluentValidationExtensions.Processor.Configs
{
    public sealed partial class ProcessorItemSlotData
    {
        public sealed class Validator
            : AbstractValidator<ProcessorInputData>
        {
        }
    }
}

