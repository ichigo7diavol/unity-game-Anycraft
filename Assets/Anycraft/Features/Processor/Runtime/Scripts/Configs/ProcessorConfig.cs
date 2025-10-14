using Anycraft.FluentValidationExtensions.Configs.Index;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Processor.Configs
{
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(FluentValidationExtensions) + "/" + nameof(Processor) + "/" + nameof(Configs) + "/" + nameof(ProcessorConfig))]
    public sealed partial class ProcessorConfig : BaseIndexedConfig
    {
        [SerializeField] private ProcessorData _data;

        [SerializeField] private ProcessorInputData _inputData;
        [SerializeField] private ProcessorOutputData _outputData;

        public ProcessorData Data => _data;

        public ProcessorInputData InputData => _inputData;
        public ProcessorOutputData OutputData => _outputData;
    }
}

