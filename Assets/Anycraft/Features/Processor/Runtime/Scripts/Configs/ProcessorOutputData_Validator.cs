using FluentValidation;

namespace Anycraft.FluentValidationExtensions.Processor.Configs
{
    public sealed partial class ProcessorOutputData
    {
        public sealed class Validator
            : AbstractValidator<ProcessorOutputData>
        {
        }
    }
}

