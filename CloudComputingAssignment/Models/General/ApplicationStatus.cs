namespace Entities.Models.General
{
    public enum ApplicationStatus
    {
        Processing,
        ReadyToSend,
        PendingAcceptance,
        Accepted,
        Rejected,
        Expired
    }
}