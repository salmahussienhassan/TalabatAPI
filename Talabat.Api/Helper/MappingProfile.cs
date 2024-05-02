using AutoMapper;
using Talabat.Api.DTOS;
using Talabat.Core.Entities;

namespace Talabat.Api.Helper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductToReturnDTO>( )
                .ForMember(d=>d.ProductBrand, o=>o.MapFrom(s=>s.ProductBrand.Name) )
                 .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                 .ForMember(d=>d.PictureUrl, o=>o.MapFrom<PictureUrlResolver>());
        }
    }
}
