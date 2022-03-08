namespace RFQ.Core.Entities
{
    using Options;

    public interface ITrackable
    {
        void Visit(Reason reason);
    }
}
