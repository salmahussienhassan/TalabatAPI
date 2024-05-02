using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Api.DTOS;
using Talabat.Api.Errors;
using Talabat.Api.Helper;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;

namespace Talabat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : APIBaseController
    {
        private readonly IGenericRepository<Product> _ProductRepo;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductType> _typeRepo;

        public ProductController(IGenericRepository<Product> ProductRepo,IMapper mapper,IGenericRepository<ProductBrand>BrandRepo,
            IGenericRepository<ProductType> TypeRepo)
        {
            this._ProductRepo = ProductRepo;
            this._mapper = mapper;
            _brandRepo = BrandRepo;
            _typeRepo = TypeRepo;
        }

        //baseurl/api/product
        [HttpGet]
        public async Task<ActionResult< IReadOnlyList<Pagination<ProductToReturnDTO>>>> GetAllProducts([FromQuery]ProductSpecParams Params)
        {
            var spec = new ProductSpecification(Params);
            var Products = await _ProductRepo.GetAllAsyncWithSpec(spec);

            var MappedProducts = _mapper.Map< IReadOnlyList< Product>, IReadOnlyList< ProductToReturnDTO>>(Products);

            var CountSpec = new ProductWithFilterationForCount(Params);

            var count = await _ProductRepo.GetCountWithSpecAsync(CountSpec);

            return Ok(new Pagination<ProductToReturnDTO>(Params.PageIndex,Params.PageSize,count,MappedProducts));
        }


        //baseurl/api/product/1
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductToReturnDTO), 200)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDTO>> GetProductById(int id)
        {
            var spec = new ProductSpecification(id);
            var Product = await _ProductRepo.GetByIdAsyncWithSpec(spec);

            if (Product is null)
                return NotFound(new ApiResponse(404));

            var MappedProduct=_mapper.Map<Product,ProductToReturnDTO>(Product);

            return Ok(MappedProduct);
        }

        //baseurl/api/product/Brand
        [HttpGet("Brand")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllBrands()
        {
            var Brands = await _brandRepo.GetAllAsync();
            return Ok(Brands);
        }

        //baseurl/api/product/Types
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllTypes()
        {
            var Types = await _typeRepo.GetAllAsync();
            return Ok(Types);
        }
    }
}
