using AutoMapper;
using Talabat.Api.DTOS;
using Talabat.Core.Entities;

namespace Talabat.Api.Helper
{
    public class PictureUrlResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public PictureUrlResolver(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
           return string.IsNullOrEmpty(source.PictureUrl) ? string.Empty : $"{_configuration["BaseUrl"]}{source.PictureUrl}";
        }
    }
}
