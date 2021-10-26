using AutoMapper;
using E_commerce.Helpers;
using E_commerce.Data.Models;
using E_commerce.Shared.DTO.Product;

namespace E_commerce.Data.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Products, ProductDTO>()
                .ForMember(src => src.PictureUrl,
                           opts => opts
                                    .MapFrom(src => ImageHelper
                                                        .GetFileUrl(src.PictureUrl)
                                            ));
        }
    }
}
