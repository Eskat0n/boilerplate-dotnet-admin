namespace Boilerplate.Core.Traits
{
    public interface IReferencable<out TId>
    {
        TId Id { get; }
        string GetName();
    }
}
