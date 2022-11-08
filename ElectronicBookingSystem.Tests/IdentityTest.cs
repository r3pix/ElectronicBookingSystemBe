using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Identity.Commands;
using ElectronicBookingSystem.Application.Profiles;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ElectronicBookingSystem.Tests
{
    public class IdentityTest
    {
        private static readonly DbContextOptions<ElectronicBookingSystemDbContext> _options = new DbContextOptionsBuilder<ElectronicBookingSystemDbContext>()
            .UseInMemoryDatabase(databaseName: "Test_Booking_Identity").Options;
        

        [Fact]
        public async Task WhenNonExisting_ItShouldThrowError()
        {
            //arrange
            var mapper = new Mock<IMapper>();
            var repository = new Mock<IRepository<Identity>>();
            //act
            var command = new UpdateIdentityCommand();
            var commandHandler = new UpdateIdentityCommandHandler(repository.Object, mapper.Object);

            //assert
            await Assert.ThrowsAsync<Exception>(async () => await commandHandler.Handle(command, CancellationToken.None));
        } 

        [Fact]
        public async Task WhenUpdating_ItShouldUpdateData()
        {
            //arrange
            var profile = new IdentityAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var dbContext = new ElectronicBookingSystemDbContext(_options);
            var repository = new Repository<Identity>(dbContext, mapper);

            //act
            await dbContext.Identities.AddRangeAsync(InMemorySeeds.GetMockedIdentitySet());
            await dbContext.SaveChangesAsyncWithoutUser();

            var command = new UpdateIdentityCommand
            {
                LastName = "lol",
                Name = "test",
                Id = Guid.Parse("6c77009a-bdf4-4881-8e73-cbf06b075bc3")
            };
            var commandHandler = new UpdateIdentityCommandHandler(repository, mapper);

            await commandHandler.Handle(command, CancellationToken.None);

            var expected = "test";
            //assert
            Assert.Equal((await dbContext.Identities.FirstOrDefaultAsync(x=>x.Id == Guid.Parse("6c77009a-bdf4-4881-8e73-cbf06b075bc3"))).Name, expected);
        }
    }
}
