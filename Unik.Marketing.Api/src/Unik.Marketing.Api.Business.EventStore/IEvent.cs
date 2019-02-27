namespace Unik.Marketing.Api.Business.EventStore
{
    public interface IEvent
    {
        int Version { get; set; }
    }
}