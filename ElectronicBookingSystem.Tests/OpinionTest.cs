using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Opinion.Queries;
using ElectronicBookingSystem.Application.Profiles;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Interfaces;
using ElectronicBookingSystem.Infrastructure.Services;
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
    public class OpinionTest
    {
        private readonly DbContextOptions<ElectronicBookingSystemDbContext> _options = new DbContextOptionsBuilder<ElectronicBookingSystemDbContext>()
           .UseInMemoryDatabase(databaseName: "Test_Booking_Opinion").Options;

        [Fact]
        public async Task WhenChecking_ItSouldReturnValue()
        {
            //arrange
            var profile = new OpinionAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var currentUser = new Mock<ICurrentUserService>();
            currentUser.Setup(x => x.Email).Returns("system");
            var dbContext = new ElectronicBookingSystemDbContext(_options, currentUser.Object);
            var repository = new Repository<Booking>(dbContext, mapper);
            //act

            var command = new CheckIsOpinionAllowedQuery
            {
                RoomId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };

            var commandHandler = new CheckIsOpinionAllowedQueryHandler(repository);
            var result = await commandHandler.Handle(command, CancellationToken.None);
            //assert
            Assert.False(result.Result);
        }
    }
}
