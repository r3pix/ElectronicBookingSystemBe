using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Service.Commands;
using ElectronicBookingSystem.Application.CQRS.Service.Queries;
using ElectronicBookingSystem.Application.Repositories;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Interfaces;
using ElectronicBookingSystem.Infrastructure.Services;
using ElectronicLibrary.Application.CQRS.Service.Commands;
using ElectronicLibrary.Application.CQRS.Service.Queries;
using ElectronicLibrary.Application.Profiles;
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
    public class ServiceTest
    {
        private readonly DbContextOptions<ElectronicBookingSystemDbContext> _options = new DbContextOptionsBuilder<ElectronicBookingSystemDbContext>()
           .UseInMemoryDatabase(databaseName: "Test_Booking_Service").Options;

        [Fact]
        public async Task WhenProvidedWithData_ItShouldCreateEntity()
        {
            //arrange
            var profile = new ServiceAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var dbContext = DbContextHelper.GetMockedDbContext();
            var repository = new ServiceRepository(dbContext.Object, mapper);

            var command = new AddServiceCommand();
            var commandHandler = new AddServiceCommandHandler(repository, mapper);
            var pre = dbContext.Object.Set<Service>().Count();
            //act
            await commandHandler.Handle(command, CancellationToken.None);
            var post = dbContext.Object.Set<Service>().Count();
            //assert
            Assert.NotEqual(pre, post);
        }

        [Fact]
        public async Task WhenUpdating_ItShouldUpdateData()
        {
            //arrange
            var profile = new ServiceAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var dbContext = DbContextHelper.GetMockedDbContext();
            var repository = new ServiceRepository(dbContext.Object, mapper);

            var command = new UpdateServiceCommand
            {
                Id = Guid.Parse("0307b01f-8024-4b27-a407-3fcccc3d202b"),
                Name = "mmm"
            };

            var commandHandler = new UpdateServiceCommandHandler(repository, mapper);

            //act
            await commandHandler.Handle(command, CancellationToken.None);
            dbContext.Verify(x => x.Set<Service>().Update(It.IsAny<Service>()), Times.Once);
        }

        [Fact]
        public async Task WhenGettingPageable_ItShouldReturnData()
        {
            //arrange
            var profile = new ServiceAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var currentUser = new Mock<ICurrentUserService>();
            currentUser.Setup(x => x.Email).Returns("system");
            var dbContext = new ElectronicBookingSystemDbContext(_options, currentUser.Object);
            var repository = new PageableServicesRepository(dbContext);

            //act
            var query = new GetPageableServicesQuery
            {
                Page = new Infrastructure.Models.Page
                {
                    Desc = true,
                    OrderBy = "CreateDate",
                    PageNumber = 1,
                    PageSize = 1
                },
                Filter = new Infrastructure.Models.Service.GetPageableServicesFilter
                {
                    SearchTerm = ""
                }
            };

            var handler = new GetPageableServicesQueryHandler(repository, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task WhenGettingForSelect_ItShouldReturnData()
        {
            //arrange
            var currentUser = new Mock<ICurrentUserService>();
            currentUser.Setup(x => x.Email).Returns("system");
            var dbContext = new ElectronicBookingSystemDbContext(_options, currentUser.Object);
            var mapper = new Mock<IMapper>();
            var repository = new ServiceRepository(dbContext, mapper.Object);
            //act
            var query = new GetServicesForSelectQuery();
            var handler = new GetServicesForSelectQueryHandler(repository);

            var result = await handler.Handle(query, CancellationToken.None);
            //assert

            Assert.NotNull(result);
        }

        [Fact]
        public async Task WhenGettingById_ItShouldReturnData()
        {
            //arrange
            var currentUser = new Mock<ICurrentUserService>();
            currentUser.Setup(x => x.Email).Returns("system");
            var dbContext = new ElectronicBookingSystemDbContext(_options, currentUser.Object);
            var mapper = new Mock<IMapper>();
            var repository = new ServiceRepository(dbContext, mapper.Object);

            //act
            await dbContext.Services.AddRangeAsync(InMemorySeeds.GetMockedServiceSet());
            await dbContext.SaveChangesAsyncWithoutUser();

            var resultt = await dbContext.Decorations.ToListAsync();

            var query = new GetServiceByIdQuery
            {
                Id = Guid.Parse("77811725-b5fb-4840-9c6c-8ac41423757b")
            };

            var queryHandler = new GetServiceByIdQueryHandler(repository, mapper.Object);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
        }
    }
}
