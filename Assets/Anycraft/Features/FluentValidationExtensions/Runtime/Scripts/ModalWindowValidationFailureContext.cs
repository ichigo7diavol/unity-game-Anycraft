using System.Collections.Generic;
using FluentValidation;

namespace Anycraft.Features.FluentValidationExtensions
{
    public sealed partial class ModalWindowValidationFailureContext
    {
        public partial struct FailureEntry
        {
            private IValidatable _validatable;
            private ValidationException _exception;
        
            private IValidatable Validatable => _validatable;
            private ValidationException Exception => _exception;

            public FailureEntry(IValidatable validatable,
                ValidationException exception)
            {
                _validatable = validatable;
                _exception = exception;
            }
        }

        private readonly List<FailureEntry> _entries = new();
        private IReadOnlyList<FailureEntry> Entries => _entries;
    }
}