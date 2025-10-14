using FluentValidation;

namespace Anycraft.Features.Processor
{
    public sealed partial class ProcessorResourceSlotData
    {
        public sealed class Validator
            : AbstractValidator<ProcessorResourceSlotData>
        {
        }
    }
}

