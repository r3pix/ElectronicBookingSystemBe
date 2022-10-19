using System;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Interfaces
{
    public interface IInlineEmailMessageService
    {
        Task<string> GetHtmlRegisterMessage(string userEmail);
        Task<string> GetHtmlBookingMessage(Guid bookingId);
        Task<string> GetHtmlCancelMessage(Guid bookingId);
    }
}