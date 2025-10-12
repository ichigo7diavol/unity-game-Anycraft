using Anycraft.Utils;

namespace Anycraft.Frame.Configs
{
    public interface IConfig : IValidatable
    {
        public string Id { get; }
    }
}