using Anycraft.Features.Configs.Index;
using UnityEngine;

namespace Anycraft.Features.Processor
{
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Processor) + "/" + nameof(ProcessorConfig))]
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

