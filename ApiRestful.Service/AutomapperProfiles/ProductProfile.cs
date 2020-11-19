using ApiRestful.Service.ExternalDtos;
using ApiRestful.Service.Entities;
using AutoMapper;

namespace ApiRestful.Service.AutomapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductExternalDto>();            
            CreateMap<ProductExternalDto, ProductEntity>();            
        }
    }
}
