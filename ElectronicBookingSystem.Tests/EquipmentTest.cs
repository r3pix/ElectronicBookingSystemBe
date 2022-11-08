using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Equipment.Commands;
using ElectronicBookingSystem.Application.CQRS.Equipment.Queries;
using ElectronicBookingSystem.Application.Repositories;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Application.CQRS.Equipment.Queries;
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
    public class EquipmentTest
    {

        private static readonly DbContextOptions<ElectronicBookingSystemDbContext> _options = new DbContextOptionsBuilder<ElectronicBookingSystemDbContext>()
            .UseInMemoryDatabase(databaseName: "Test_Booking_Equipment").Options;

        [Fact]
        public async Task WhenUpdating_ItShouldUpdateData()
        {
            //arrange
            var profile = new EquipmentAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var dbContext = DbContextHelper.GetMockedDbContext();
            var repository = new EquipmentRepository(dbContext.Object, mapper);

            var command = new UpdateEquipmentCommand
            {
                Id = Guid.Parse("0307b01f-8024-4b27-a407-3fcccc3d202b"),
                Name = "mmm"
            };

            var commandHandler = new UpdateEquipmentCommandHandler(repository, mapper);

            //act
            await commandHandler.Handle(command, CancellationToken.None);
            dbContext.Verify(x => x.Set<Equipment>().Update(It.IsAny<Equipment>()), Times.Once);
        }

        [Fact]
        public async Task WhenGettingPageable_ItShouldReturnData()
        {
            //arrange
            var profile = new DecorationAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var dbContext = new ElectronicBookingSystemDbContext(_options);
            var repository = new PageableEquipmentRepository(dbContext);

            //act
            var query = new GetPageableEquipmentQuery
            {
                Page = new Infrastructure.Models.Page
                {
                    Desc = true,
                    OrderBy = "CreateDate",
                    PageNumber = 1,
                    PageSize = 1
                },
                Filter = new Infrastructure.Models.Equipment.GetPageableEquipmentFilter
                {
                    SearchTerm = ""
                }
            };

            var handler = new GetPageableEquipmentQueryHandler(repository, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task WhenGettingForSelect_ItShouldReturnData()
        {
            //arrange
            var dbContext = new ElectronicBookingSystemDbContext(_options);
            var mapper = new Mock<IMapper>();
            var repository = new EquipmentRepository(dbContext, mapper.Object);
            //act
            var query = new GetEquipmentForSelectQuery();
            var handler = new GetEquipmentForSelectQueryHandler(repository);

            var result = await handler.Handle(query, CancellationToken.None);
            //assert

            Assert.NotNull(result);
        }

        [Fact]
        public async Task WhenGettingById_ItShouldReturnData()
        {
            //arrange
            var dbContext = new ElectronicBookingSystemDbContext(_options);
            var mapper = new Mock<IMapper>();
            var repository = new EquipmentRepository(dbContext, mapper.Object);

            //act

            var resultt = await dbContext.Decorations.ToListAsync();

            var query = new GetEquipmentByIdQuery
            {
                Id = Guid.Parse("83f8a698-2850-42f7-914a-0d7cc9a443ee")
            };

            var queryHandler = new GetEquipmentByIdQueryHandler(repository, mapper.Object);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
        }
    }
}
