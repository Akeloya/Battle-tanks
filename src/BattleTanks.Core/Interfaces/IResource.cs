namespace BattleTanks.Core.Interfaces
{
    public interface IResource
    {
        short Value { get; init;}
    }

    public interface INationalResource : IResource, INational
    {
    }
}
