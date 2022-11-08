using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Decoration.Commands;
using ElectronicBookingSystem.Application.CQRS.Decoration.Queries;
using ElectronicBookingSystem.Application.Repositories;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Interfaces;
using ElectronicBookingSystem.Infrastructure.Services;
using ElectronicLibrary.Application.CQRS.Decoration.Commands;
using ElectronicLibrary.Application.CQRS.Decoration.Queries;
using ElectronicLibrary.Application.Profiles;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Infrastructure.Models;
using ElectronicLibrary.Infrastructure.Services;
using ElectronicLibrary.Persistance;
using Microsoft.AspNetCore.Http;
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
    public class DecorationTest
    {

        private static readonly DbContextOptions<ElectronicBookingSystemDbContext> _options = new DbContextOptionsBuilder<ElectronicBookingSystemDbContext>()
            .UseInMemoryDatabase(databaseName: "Test_Booking_Decoration").Options;

        [Fact]
        public async Task WhenUpdating_ItShouldUpdateData()
        {
            //arrange
            var profile = new DecorationAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var dbContext = DbContextHelper.GetMockedDbContext();
            var repository = new DecorationRepository(dbContext.Object, mapper);

            var command = new UpdateDecorationCommand
            {
                Id = Guid.Parse("0307b01f-8024-4b27-a407-3fcccc3d202b"),
                Name = "mmm"
            };

            var commandHandler = new UpdateDecorationCommandHandler(repository, mapper);

            //act
            await commandHandler.Handle(command, CancellationToken.None);
            dbContext.Verify(x => x.Set<Decoration>().Update(It.IsAny<Decoration>()), Times.Once);
        }

        [Fact]
        public async Task WhenGettingPageable_ItShouldReturnData()
        {
            //arrange
            var profile = new DecorationAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var currentUser = new Mock<ICurrentUserService>();
            currentUser.Setup(x => x.Email).Returns("system");
            var dbContext = new ElectronicBookingSystemDbContext(_options, currentUser.Object);
            var repository = new PageableDecorationsRepository(dbContext);

            //act
            var query = new GetPageableDecorationsQuery
            {
                Page = new Infrastructure.Models.Page
                {
                    Desc = true,
                    OrderBy = "CreateDate",
                    PageNumber = 1,
                    PageSize = 1
                },
               Filter = new Infrastructure.Models.Decoration.GetPageableDecorationsFilter
                {
                    SearchTerm = ""
                }
            };

            var handler = new GetPageableDecorationsQueryHandler(repository, mapper);

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
            var repository = new DecorationRepository(dbContext, mapper.Object);
            //act
            var query = new GetDecorationsForSelectQuery();
            var handler = new GetDecorationsForSelectQueryHandler(repository);

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
            var repository = new DecorationRepository(dbContext, mapper.Object);

            //act
            await dbContext.Decorations.AddRangeAsync(InMemorySeeds.GetMockedDecorationSet());
            await dbContext.SaveChangesAsyncWithoutUser();

            var resultt = await dbContext.Decorations.ToListAsync();

            var query = new GetDecorationByIdQuery
            {
                Id = Guid.Parse("83f8a698-2850-42f7-914a-0d7cc9a443ee")
            };

            var queryHandler = new GetDecorationByIdQueryHandler(repository, mapper.Object);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
        }
    }
}
