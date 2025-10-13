using Anycraft.Features.Configs.Index;
using UnityEngine;

namespace Anycraft.Features.Processor.Configs
{
    [CreateAssetMenu(menuName = "Anycraft/Processor/" + nameof(ProcessorConfig))]
    public sealed class ProcessorConfig : BaseIndexedConfig
    {
        [SerializeField] private ProcessorData _data;

        [SerializeField] private ProcessorInputData _inputData;
        [SerializeField] private ProcessorOutputData _outputData;

        public ProcessorData Data => _data;

        public ProcessorInputData InputData => _inputData;
        public ProcessorOutputData OutputData => _outputData;
    }
}

