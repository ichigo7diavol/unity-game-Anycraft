using FluentValidation;
using UnityEngine;

namespace Anycraft.Features.Processor
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

