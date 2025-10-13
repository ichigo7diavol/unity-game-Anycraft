using Anycraft.Features.Validation;

namespace Anycraft.Features.Configs
{
    public interface IConfig : IValidatable
    {
        public string Id { get; }
    }
}