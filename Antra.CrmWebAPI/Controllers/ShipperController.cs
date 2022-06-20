using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CrmWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperServiceAsync shipperServiceAsync;
        public ShipperController(IShipperServiceAsync shipperServiceAsync)
        {
            this.shipperServiceAsync = shipperServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = shipperServiceAsync.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await shipperServiceAsync.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Shipper with Id = {id} is not found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ShipperModel model)
        {
            var result = await shipperServiceAsync.AddShipperAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ShipperModel model)
        {
            var result = await shipperServiceAsync.UpdateShipperAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await shipperServiceAsync.DeleteShipperAsync(id);
            if (result > 0)
                return Ok("Category Deleted successfully");
            return BadRequest();
        }
    }
}
