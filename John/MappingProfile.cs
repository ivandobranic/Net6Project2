using AutoMapper;
using Common.DataTransferObjects;
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
        }

        #endregion Constructors
    }
}