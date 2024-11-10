using AutoMapper;
using SportyApp.DTO.ProductImages;
using SportyApp.DTO.Products;
using SportyApp.Models;

namespace SportyApp.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<CreateProductDto, Products>().ReverseMap(); 
            CreateMap<ProductListDto, Products>().ReverseMap();
            CreateMap<ProductFindByDto, Products>().ReverseMap();
            CreateMap<ProductImageDto, ProductImages>().ReverseMap();
            CreateMap<ProductImageListDto, ProductImages>().ReverseMap();
        }
    }
}
