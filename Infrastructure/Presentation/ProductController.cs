using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using Shared.ErrorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IServiceManager serviceManager): ControllerBase
    {
        [HttpGet("Products")]
        public async Task<ActionResult<IEnumerable<ProductResultDTO>>> GetAllProduct([FromQuery]ProductSpecificationParameters parameters)
        {
           var products = await serviceManager.ProductService.GetAllProductsAsync(parameters);
            return Ok(products);
        }


        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDTO>>> GetAllBrands()
        {
            var Brands = await serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(Brands);
        }

        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResultDTO>>> GetAllTypes()
        {
            var types = await serviceManager.ProductService.GetAllTypesAsync();
            return Ok(types);
        }

        //for Swagger 
        [ProducesResponseType(typeof (ErrorDetails),(int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof (ErrorDetails),(int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof (ValidationErrorsResponse),(int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof (ProductResultDTO),(int)HttpStatusCode.OK)]
        //------------
        [HttpGet("Product/{id}")]
        public async Task<ActionResult<ProductResultDTO>> GetProduct(int id)
        {
            var product = await serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }

    }
}
