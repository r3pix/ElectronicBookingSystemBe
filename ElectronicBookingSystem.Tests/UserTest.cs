using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.User.Querries;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Interfaces;
using ElectronicBookingSystem.Infrastructure.Models;
using ElectronicBookingSystem.Infrastructure.Services;
using ElectronicLibrary.Application.CQRS.User.Commands;
using ElectronicLibrary.Application.CQRS.User.Querries;
using ElectronicLibrary.Application.Profiles;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    public class UserTest
    {

        private readonly DbContextOptions<ElectronicBookingSystemDbContext> _options = new DbContextOptionsBuilder<ElectronicBookingSystemDbContext>()
           .UseInMemoryDatabase(databaseName: "Test_Booking_User").Options;

        [Fact]
        public async Task WhenAddingUser_ItShoudAddEntity()
        {
            //arrange
            var profile = new UserAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var builder = new ConfigurationBuilder().AddJsonFile($"testsettings.json", optional: false);
            var _config = builder.Build();
            var currentUser = new Mock<ICurrentUserService>();
            currentUser.Setup(x => x.Email).Returns("system");
            var dbContext = new ElectronicBookingSystemDbContext(_options, currentUser.Object);
            var repository = new Repository<User>(dbContext, mapper);
            var roleRepository = new Repository<Role>(dbContext, mapper);
            var passwordHasher = new PasswordHasher<User>();
            var emailConfiguration = _config.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            var appData = _config.GetSection("AppData").Get<AppData>();
            var emailSender = new EmailSender(emailConfiguration);
            var inlineMessageService = new InlineEmailMessageService(dbContext, appData);
            //act
            if (!await dbContext.Roles.AnyAsync())
                await dbContext.Roles.AddRangeAsync(InMemorySeeds.GetMockedRoleSet());
            await dbContext.SaveChangesAsyncWithoutUser();

            var command = new RegisterUserCommand
            {
                Email = "admin@com.pl",
                City = "Test",
                LastName = "Test",
                Name = "Test",
                Number = "10",
                Password = "Test",
                PostalCode = "25-520",
                Street = "Test"
            };

            var commandHandler = new RegisterUserCommandHandler(repository, mapper, passwordHasher, roleRepository, emailSender, inlineMessageService);
            await commandHandler.Handle(command, CancellationToken.None);
            //assert

            Assert.True(await dbContext.Users.AnyAsync());

        }

        [Fact]
        public async Task WhenLogging_ItShouldReturnToken()
        {
            //arrange
            var profile = new UserAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var builder = new ConfigurationBuilder().AddJsonFile($"testsettings.json", optional: false);
            var _config = builder.Build();
            var currentUser = new Mock<ICurrentUserService>();
            currentUser.Setup(x => x.Email).Returns("system");
            var dbContext = new ElectronicBookingSystemDbContext(_options, currentUser.Object);
            var repository = new UserRepository(dbContext, mapper);
            var roleRepository = new Repository<Role>(dbContext, mapper);
            var passwordHasher = new PasswordHasher<User>();
            var emailConfiguration = _config.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            var appData = _config.GetSection("AppData").Get<AppData>();
            var emailSender = new EmailSender(emailConfiguration);
            var inlineMessageService = new InlineEmailMessageService(dbContext, appData);
            //act
            if(!await dbContext.Roles.AnyAsync())
                await dbContext.Roles.AddRangeAsync(InMemorySeeds.GetMockedRoleSet());
            await dbContext.Users.AddRangeAsync(InMemorySeeds.GetMockedUserSet());
            await dbContext.Identities.AddRangeAsync(InMemorySeeds.GetMockedIdentitySet());
            await dbContext.SaveChangesAsyncWithoutUser();

            var command = new LoginUserQuery
            {
                Email = "admin@com.pl",
                Password = "Pass123$"
            };

            var commandHandler = new LoginUserQueryHandler(repository, passwordHasher, _config);
            var result = await commandHandler.Handle(command, CancellationToken.None);
            //assert

            Assert.NotNull(result);
        }

        [Fact]
        public async Task WhenLoggingWithNonExisting_ItShouldthrowError()
        {
            //arrange
            var profile = new UserAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var builder = new ConfigurationBuilder().AddJsonFile($"testsettings.json", optional: false);
            var _config = builder.Build();
            var currentUser = new Mock<ICurrentUserService>();
            currentUser.Setup(x => x.Email).Returns("system");
            var dbContext = new ElectronicBookingSystemDbContext(_options, currentUser.Object);
            var repository = new UserRepository(dbContext, mapper);
            var roleRepository = new Repository<Role>(dbContext, mapper);
            var passwordHasher = new PasswordHasher<User>();
            var emailConfiguration = _config.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            var appData = _config.GetSection("AppData").Get<AppData>();
            var emailSender = new EmailSender(emailConfiguration);
            var inlineMessageService = new InlineEmailMessageService(dbContext, appData);
            //act

            var command = new LoginUserQuery
            {
                Email = "admiaan@com.pl",
                Password = "Pass123$"
            };

            var commandHandler = new LoginUserQueryHandler(repository, passwordHasher, _config);
            //assert

            await Assert.ThrowsAsync<Exception>(async () => await commandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task WhenGettingUserData_ItShouldReturnData()
        {
            //arrange
            var profile = new UserAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var currentUser = new Mock<ICurrentUserService>();
            currentUser.Setup(x => x.Email).Returns("system");
            var dbContext = new ElectronicBookingSystemDbContext(_options, currentUser.Object);
            var repository = new UserRepository(dbContext, mapper);
            //act
            var command = new GetUserDataQuery
            {
                Email = "admin@com.pl"
            };

            var commandHandler = new GetUserDataQueryHandler(repository, mapper);

            var result = await commandHandler.Handle(command, CancellationToken.None);

            //assert
            Assert.NotNull(result);

        }
    }
}
