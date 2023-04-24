using AutoMapper;
using Common.DataTransferObjects.Product;
using Common.DataTransferObjects.User;
using Entities.Models;

namespace John
{
    public class MappingProfile : Profile
    {
        #region Constructors

        public MappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductCategoryCreateDto, ProductCategory>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<UserCreateDto, User>();
        }

        #endregion Constructors
    }
}