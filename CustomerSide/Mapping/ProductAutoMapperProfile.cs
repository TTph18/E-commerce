using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using E_commerce.Shared.DTO;
using E_commerce.Shared.ViewModels;
using E_commerce.Shared.DTO.Product;
using CustomerSide.Models;
using E_commerce.Shared.DTO.Paging;

namespace CustomerSide.Mapping
{
    public class ProductAutoMapperProfile : Profile
    {
        public ProductAutoMapperProfile()
        {
            CreateMap<ProductDTO, ProductVM>().ReverseMap();
            CreateMap<BaseQueryCriteriaDTO, BaseQueryCriteriaVM>().ReverseMap();
            CreateMap<PagingResponseDTO<ProductDTO>, PagingResponseVM<ProductVM>>().ReverseMap();
        }
    }
}
