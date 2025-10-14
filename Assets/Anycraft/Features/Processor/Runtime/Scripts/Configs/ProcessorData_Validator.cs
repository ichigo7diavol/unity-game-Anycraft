using FluentValidation;
using UnityEngine;

namespace Anycraft.FluentValidationExtensions.Processor.Configs
{
    public sealed partial class ProcessorData
    {
        public sealed class Validator
            : AbstractValidator<ProcessorData>
        {
        }

        [SerializeField] private int _processingTime;
    }
}

