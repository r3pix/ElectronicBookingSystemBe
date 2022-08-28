using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Category.Commands;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Profiles
{
    public class CategoryAutomapperProfile : Profile
    {
        public CategoryAutomapperProfile()
        {
            CreateMap<AddCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Category, CategoryListModel>();
        }
    }
}
