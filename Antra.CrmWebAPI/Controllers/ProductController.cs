using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CrmWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceAsync productServiceAsync;
        private readonly IVendorServiceAsync vendorServiceAsync;
        private readonly ICategoryServiceAsync categoryServiceAsync;
        public ProductController(IProductServiceAsync productServiceAsync, IVendorServiceAsync vendorServiceAsync, ICategoryServiceAsync categoryServiceAsync)
        {
            this.productServiceAsync = productServiceAsync;
            this.vendorServiceAsync = vendorServiceAsync;
            this.categoryServiceAsync = categoryServiceAsync;   
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await productServiceAsync.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await productServiceAsync.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Product with Id = {id} is not found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductRequestModel model)
        {
            var result = await productServiceAsync.AddProductAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductRequestModel model)
        {
            var result = await productServiceAsync.UpdateProductAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await productServiceAsync.DeleteProductAsync(id);
            if (result > 0)
                return Ok("Product Deleted successfully");
            return BadRequest();
        }
    }
}
