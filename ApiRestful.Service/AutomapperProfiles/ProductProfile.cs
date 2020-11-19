using ApiRestful.Service.Dtos;
using ApiRestful.Service.Entities;
using AutoMapper;

namespace ApiRestful.Service.AutomapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductDto>();            
            CreateMap<ProductDto, ProductEntity>();            
        }
    }
}
