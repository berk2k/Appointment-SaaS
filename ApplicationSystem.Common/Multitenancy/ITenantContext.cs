namespace AppointmentSystem.Common.Multitenancy
{
    public interface ITenantContext
    {
        string TenantId { get; }
        string Domain { get; }
        string Plan { get; }
        string Status { get; }
        bool IsActive { get; }
    }
}
