using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Technical.Application.Contracts;
using Technical.Application.Dtos.Products;

namespace Technical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService) 
        {
            this._productsService = productsService;
        }

        [HttpGet ("GetProducts")]
        public IActionResult Get()
        {
            var result = this._productsService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("SaveProduct")]
        public IActionResult Post([FromBody] ProductsDtoAdd productsDtoAdd) 
        {
            var result = this._productsService.Save(productsDtoAdd);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("UpdateProduct")]
        public IActionResult Put([FromBody] ProductsDtoUpdate productsDtoUpdate) 
        {
            var result = this._productsService.Update(productsDtoUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("RemoveProduct")]
        public IActionResult Remove([FromBody] ProductsDtoRemove productsDtoRemove) 
        {
            var result = this._productsService.Remove(productsDtoRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
