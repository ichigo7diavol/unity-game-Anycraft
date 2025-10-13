using JetBrains.Annotations;

namespace Anycraft.Features.Validation
{
    [UsedImplicitly]
    [System.Serializable]
    public class ValidatationException : System.Exception
    {
        public ValidatationException() { }
        public ValidatationException(string message) : base(message) { }
        public ValidatationException(string message, System.Exception inner) : base(message, inner) { }
        protected ValidatationException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

