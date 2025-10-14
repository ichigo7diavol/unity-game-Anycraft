using FluentValidation;

namespace Anycraft.FluentValidationExtensions.Processor.Configs
{
    public sealed partial class ProcessorInputData
    {
        public sealed class Validator
            : AbstractValidator<ProcessorInputData>
        {
        }
    }
}

