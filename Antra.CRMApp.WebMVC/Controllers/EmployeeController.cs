using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;
        private readonly IRegionServiceAsync regionServiceAsync;
        public EmployeeController(IEmployeeServiceAsync empService,IRegionServiceAsync reg)
        {
            employeeServiceAsync = empService;
            regionServiceAsync = reg;
        }

        public async Task<IActionResult> Index()
        {
            var empCollection = await employeeServiceAsync.GetAllAsync();
            if(empCollection != null)
                return View(empCollection);
            List<EmployeeResponseModel> model = new List<EmployeeResponseModel>();
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
        public async Task<IActionResult> Create(EmployeeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeServiceAsync.AddEmployeeAsync(model);
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
            var empModel = await employeeServiceAsync.GetEmployeeForEditAsync(id);
            var regCollection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(regCollection, "Id", "Name");
            return View(empModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeRequestModel model)
        {
            ViewBag.IsEdit = false;
            var regCollection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(regCollection, "Id", "Name");
            if (ModelState.IsValid)
            {
                await employeeServiceAsync.UpdateEmployeeAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await employeeServiceAsync.DeleteEmployeeAsync(id);
            return RedirectToAction("Index");
        }
    }
}
