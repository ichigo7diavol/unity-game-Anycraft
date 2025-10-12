namespace Anycraft.Utils
{
    public interface IValidatable
    {
        bool Validate(ref string errorMessage);
    }
}

