using System;
using System.Threading.Tasks;
using ElectronicBookingSystem.Infrastructure.Interfaces;
using ElectronicBookingSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElectronicBookingSystem.Infrastructure.Services
{
    public class InlineEmailMessageService : IInlineEmailMessageService
    {
        private readonly IElectronicBookingSystemDbContext _dbContext;
        private readonly AppData _appData;

        private string registerMessage= "<h1>Witaj {0}!</h1>"+
                                        "<br>"+
                                        "<h3>Dziękujemy za założenie konta w systemie rezerwacji sal okolicznościowych. "+
                                        "Z pomocą systemu możesz w łatwy sposób dokonać rezerwacji sali lub ją usunąć. "+
                                        "Wejdż na {1} i zaloguj się na swoje konto korzytając z danych przekazanych w rejestracji konta.</h3>";

        private string bookingMessage = "<h1>Witaj {0}!</h1>" +
                                        "<br>" +
                                        "<h3>Dziękujemy za złożenie rezerwacji. </h3>" +
                                        "<br>" +
                                        "<h4>Poniżej znajdują się szczegółowe dane rezerwacji.</h4>" +
                                        "<br>" +
                                        "<ul>" +
                                        "<li>Nazwa rezerwacji: {1}</li>" +
                                        "<li>Nazwa sali: {2}</li>" +
                                        "<li>Liczba miejsc: {3}</li>" +
                                        "<li>Liczba stołów: {4}</li>" +
                                        "<li>Koszt: {5}</li>" +
                                        "<li>Data rezerwacji: {6}</li>" +
                                        "<li>Opis: {7}</li>" +
                                        "<li>Nazwa rezerwacji: {8}</li>" +
                                        "<li>Konfiguracja dekoracji: {9}</li>" +
                                        "<li>Konfiguracja wyposażenia: {10}</li>" +
                                        "<li>Konfiguracja obsługi: {11}</li>" +
                                        "</ul>" +
                                        "<br>" +
                                        "<h5>Możesz anulować rezerwację w dowolnym momencie</h5>";

        private string cancelMessage = "<h1>Witaj {0}!</h1>" +
                                       "<br>" +
                                       "<h3>Twoja rezerwacja o identyfikatorze: {0} i nazwie {1} została anulowana.</h3>";
        
        public InlineEmailMessageService(IElectronicBookingSystemDbContext dbContext, AppData appData)
        {
            _dbContext = dbContext;
            _appData = appData;
        }

        public async Task<string> GetHtmlRegisterMessage(string userEmail)
        {
            var userEntity = await _dbContext.Users.Include(x => x.Identity).FirstOrDefaultAsync(x => x.Email == userEmail);
            return string.Format(registerMessage, userEntity.Identity.Name, _appData.ApplicationAddress);
        }
        
        public async Task<string> GetHtmlBookingMessage(Guid bookingId)
        {
            var bookingEntity = await _dbContext.Bookings
                .Include(x => x.User).ThenInclude(x=>x.Identity)
                .Include(x => x.Decoration)
                .Include(x => x.Equipment)
                .Include(x => x.Room)
                .Include(x => x.Service).FirstOrDefaultAsync(x => x.Id == bookingId);
            
            return string.Format(bookingMessage, bookingEntity.User.Identity.Name, bookingEntity.Name, bookingEntity.Room.Name, bookingEntity.TotalPlaces,
                bookingEntity.TotalTables, bookingEntity.TotalCost, bookingEntity.Date.ToShortDateString(), bookingEntity.Description, bookingEntity.Decoration.Name,
                bookingEntity.Equipment.Name, bookingEntity.Service.Name);
        }

        public async Task<string> GetHtmlCancelMessage(Guid bookingId)
        {
            var bookingEntity = await _dbContext.Bookings.Include(x=>x.User).ThenInclude(x=>x.Identity).FirstOrDefaultAsync(x => x.Id == bookingId);
            
            return string.Format(cancelMessage, bookingEntity.User.Identity.Name, bookingEntity.Id, bookingEntity.Name);
        }
    }
}