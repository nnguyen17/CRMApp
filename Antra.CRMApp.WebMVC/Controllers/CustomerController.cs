using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServiceAsync customerServiceAsync;
        private readonly IRegionServiceAsync regionServiceAsync;
        public CustomerController(ICustomerServiceAsync cus, IRegionServiceAsync reg)
        {
            customerServiceAsync = cus;
            regionServiceAsync = reg;
        }
        public async Task<IActionResult> Index()
        {
            var cusCollection = await customerServiceAsync.GetAllAsync();
            if (cusCollection != null)
                return View(cusCollection);
            List<CustomerResponseModel> model = new List<CustomerResponseModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var regCollection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(regCollection, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await customerServiceAsync.AddCustomerAsync(model);
                return RedirectToAction("Index");
            }
            var regCollection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(regCollection, "Id", "Name");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var cusModel = await customerServiceAsync.GetCustomerForEditAsync(id);
            var regCollection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(regCollection, "Id", "Name");
            return View(cusModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerRequestModel model)
        {
            ViewBag.IsEdit = false;
            var regCollection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(regCollection, "Id", "Name");
            if (ModelState.IsValid)
            {
                await customerServiceAsync.UpdateCustomerAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await customerServiceAsync.DeleteCustomerAsync(id);
            return RedirectToAction("Index");
        }
    }
}
