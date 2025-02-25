namespace WoT.Rush.Core.Interfaces
{
    public interface IResource
    {
        short Value { get; }
    }

    public interface INationalResource : IResource, INational
    {
    }
}
