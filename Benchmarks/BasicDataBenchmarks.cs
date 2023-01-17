using AutoMapper;
using BenchmarkDotNet.Attributes;
using ElectronicBookingSystem.Application.CQRS.Category.Queries;
using ElectronicBookingSystem.Application.CQRS.Service.Queries;
using ElectronicBookingSystem.Application.CQRS.User.Querries;
using ElectronicBookingSystem.Application.Profiles;
using ElectronicBookingSystem.Application.Repositories;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Persistance.Seeder;
using ElectronicLibrary.Application.Profiles;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Benchmarks
{
    public class BasicDataBenchmarks
    {
        DbContextOptions<ElectronicBookingSystemDbContext> options = new DbContextOptionsBuilder<ElectronicBookingSystemDbContext>()
         .UseInMemoryDatabase(databaseName: "Test_Basic").Options;

        ElectronicBookingSystemDbContext context;

        public BasicDataBenchmarks()
        {
            context = new ElectronicBookingSystemDbContext(options);
            CategorySeeder.Seed(context);
            RoleSeeder.Seed(context);
            ServiceSeeder.Seed(context);
            UserSeeder.Seed(context);
        }

        [Benchmark]
        public async Task GetCategories()
        {
            var profile = new CategoryAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new AutoMapper.Mapper(configuration);
            var repository = new CategoryPageableRepository(context);
            var query = new GetPageableCategoriesQuery
            {
                Page = new Infrastructure.Models.Page
                {
                    PageNumber = 1,
                    PageSize = 1000000,
                    OrderBy = "Id",
                    Desc = false
                },
                Filter = new Infrastructure.Models.Category.GetPageableCategoriesFilter
                {
                    SearchTerm = ""
                }
            };
            var queryHandler = new GetPageableCategoriesQueryHandler(repository, mapper);

            await queryHandler.Handle(query, CancellationToken.None);
        }

        [Benchmark]
        public async Task GetServices()
        {
            var profile = new ServiceAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new AutoMapper.Mapper(configuration);
            var repository = new PageableServicesRepository(context);
            var query = new GetPageableServicesQuery
            {
                Page = new Infrastructure.Models.Page
                {
                    PageNumber = 1,
                    PageSize = 1000000,
                    OrderBy = "Id",
                    Desc = false
                },
                Filter = new Infrastructure.Models.Service.GetPageableServicesFilter
                {
                    SearchTerm = ""
                }
            };
            var queryHandler = new GetPageableServicesQueryHandler(repository, mapper);

            await queryHandler.Handle(query, CancellationToken.None);
        }

        [Benchmark]
        public async Task GetUsers()
        {
            var profile = new UserAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new AutoMapper.Mapper(configuration);
            var repository = new UserPageableRepository(context);
            var query = new GetPageableUsersQuery
            {
                Page = new Infrastructure.Models.Page
                {
                    PageNumber = 1,
                    PageSize = 1000000,
                    OrderBy = "Id",
                    Desc = false
                },
                Filter = new Infrastructure.Models.User.GetPageableUsersFilter
                {
                    SearchTerm = ""
                }
            };
            var queryHandler = new GetPageableUsersQueryHandler(repository, mapper);

            await queryHandler.Handle(query, CancellationToken.None);
        }
    }
}
