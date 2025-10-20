using Anycraft.Features.Configs.Index;
using Anycraft.Features.FluentValidationExtensions;
using FluentValidation;

namespace Anycraft.Features.Processor
{
    public sealed partial class ProcessorConfig
    {
        public new sealed class Validator
            : AbstractValidator<ProcessorConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get<
                    BaseIndexedConfig.Validator, BaseIndexedConfig>());

                RuleFor(c => c._data)
                    .NotNull()
                    .SetValidator(ValidatorCache.Get<ProcessorData.Validator, ProcessorData>());

                RuleFor(c => c._inputData)
                    .NotNull()
                    .SetValidator(ValidatorCache.Get<ProcessorInputData.Validator, ProcessorInputData>());
                
                RuleFor(c => c._outputData)
                    .NotNull()
                    .SetValidator(ValidatorCache.Get<ProcessorOutputData.Validator, ProcessorOutputData>());
            }
        }

        public override void Validate()
        {
            this.ValidateAndThrow<
                BaseIndexedConfig.Validator, BaseIndexedConfig>();
        }
    }
}

