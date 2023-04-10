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
        }

        #endregion Constructors
    }
}