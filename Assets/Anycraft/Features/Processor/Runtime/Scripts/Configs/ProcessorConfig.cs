using Anycraft.Features.Configs.Index;
using Anycraft.Features.Validation;
using FluentValidation;
using UnityEngine;

namespace Anycraft.Features.Processor.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Processor/" + nameof(ProcessorConfig))]
    public sealed class ProcessorConfig : BaseIndexedConfig
    {
        public new sealed class Validator
            : AbstractValidator<ProcessorConfig>
        {
            public Validator()
            {
                Include(ValidatorCache.Get<BaseIndexedConfig.Validator,
                    BaseIndexedConfig>());

                RuleFor(c => c._data).NotNull();
                RuleFor(c => c._inputData).NotNull();
                RuleFor(c => c._outputData).NotNull();
            }
        }

        [SerializeField] private ProcessorData _data;

        [SerializeField] private ProcessorInputData _inputData;
        [SerializeField] private ProcessorOutputData _outputData;

        public ProcessorData Data => _data;

        public ProcessorInputData InputData => _inputData;
        public ProcessorOutputData OutputData => _outputData;

        public override void Validate()
        {
            this.ValidateAndThrow<Validator, ProcessorConfig>();
        }
    }
}

