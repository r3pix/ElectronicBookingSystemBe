using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Category.Commands;
using ElectronicBookingSystem.Application.CQRS.Category.Queries;
using ElectronicBookingSystem.Application.Profiles;
using ElectronicBookingSystem.Application.Repositories;
using ElectronicBookingSystem.Domain.Entities;
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
    public class CategoryTest
    {
        private readonly DbContextOptions<ElectronicBookingSystemDbContext> options = new DbContextOptionsBuilder<ElectronicBookingSystemDbContext>()
            .UseInMemoryDatabase(databaseName: "Test_Booking_Category").Options;

        [Fact]
        public async Task WhenProvidedWithData_ItShouldCreateEntity()
        {
            //arrange
            var profile = new CategoryAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var dbContext = DbContextHelper.GetMockedDbContext();
            var repository = new Repository<Category>(dbContext.Object, mapper);

            var command = new AddCategoryCommand();
            var commandHandler = new AddCategoryCommandHandler(repository, mapper);
            var pre = dbContext.Object.Set<Category>().Count();
            //act
            await commandHandler.Handle(command, CancellationToken.None);
            var post = dbContext.Object.Set<Category>().Count();
            //assert
            Assert.NotEqual(pre, post);
        }

        [Fact]
        public async Task WhenUpdating_ItShouldUpdateData()
        {
            //arrange
            var profile = new CategoryAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var dbContext = DbContextHelper.GetMockedDbContext();
            var repository = new Repository<Category>(dbContext.Object, mapper);

            var command = new UpdateCategoryCommand
            {
                Id = Guid.Parse("0307b01f-8024-4b27-a407-3fcccc3d202b"),
                Name = "mmm"
            };

            var commandHandler = new UpdateCategoryCommandHandler(repository, mapper);

            //act
            await commandHandler.Handle(command, CancellationToken.None);
            dbContext.Verify(x=>x.Set<Category>().Update(It.IsAny<Category>()), Times.Once);
        }

        [Fact]
        public async Task WhenGettingPageable_ItShouldReturnData()
        {
            //arrange
            var profile = new CategoryAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var dbContext = new ElectronicBookingSystemDbContext(options);
            var repository = new CategoryPageableRepository(dbContext);

            //act
            var query = new GetPageableCategoriesQuery
            {
                Page = new Infrastructure.Models.Page
                {
                    Desc = true,
                    OrderBy = "CreateDate",
                    PageNumber = 1,
                    PageSize = 1
                },
                Filter = new Infrastructure.Models.Category.GetPageableCategoriesFilter
                {
                    SearchTerm = ""
                }
            };

            var handler = new GetPageableCategoriesQueryHandler(repository, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task WhenGettingForSelect_ItShouldReturnData()
        {
            //arrange
            var dbContext = new ElectronicBookingSystemDbContext(options);
            var mapper = new Mock<IMapper>();
            var repository = new CategoryRepository(dbContext, mapper.Object);
            //act
            var query = new GetCategoriesForSelectQuery();
            var handler = new GetCategoriesForSelectQueryHandler(repository);

            var result = await handler.Handle(query, CancellationToken.None);
            //assert

            Assert.NotNull(result);
        }
    }
}
