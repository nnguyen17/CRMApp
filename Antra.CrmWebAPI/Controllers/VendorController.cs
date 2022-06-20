using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CrmWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorServiceAsync vendorServiceAsync;
        public VendorController(IVendorServiceAsync vendorServiceAsync)
        {
            this.vendorServiceAsync = vendorServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = vendorServiceAsync.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await vendorServiceAsync.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Vendor with Id = {id} is not found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VendorModel model)
        {
            var result = await vendorServiceAsync.AddVendorAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(VendorModel model)
        {
            var result = await vendorServiceAsync.UpdateVendorAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await vendorServiceAsync.DeleteVendorAsync(id);
            if (result > 0)
                return Ok("Vendor Deleted successfully");
            return BadRequest();
        }
    }
}
