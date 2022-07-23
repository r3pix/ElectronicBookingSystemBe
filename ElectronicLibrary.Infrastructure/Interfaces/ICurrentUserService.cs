namespace ElectronicBookingSystem.Infrastructure.Interfaces
{
    public interface ICurrentUserService
    {
        string Email { get; }
        string Id { get; }
        string Role { get; }
    }
}