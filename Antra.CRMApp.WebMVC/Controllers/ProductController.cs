using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServiceAsync productServiceAsync;
        private readonly IVendorServiceAsync vendorServiceAsync;
        private readonly ICategoryServiceAsync categoryServiceAsync;
        public ProductController(IProductServiceAsync prod, IVendorServiceAsync vend, ICategoryServiceAsync cate)
        {
            productServiceAsync = prod;
            vendorServiceAsync = vend;
            categoryServiceAsync = cate;
        }

        public async Task<IActionResult> Index()
        {
            var prodCollection = await productServiceAsync.GetAllAsync();
            if (prodCollection != null)
                return View(prodCollection);
            List<ProductResponseModel> model = new List<ProductResponseModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vendCollection = await vendorServiceAsync.GetAllAsync();
            ViewBag.Vendors = new SelectList(vendCollection, "Id", "Name");
            var cateCollection = await categoryServiceAsync.GetAllAsync();
            ViewBag.Categories = new SelectList(cateCollection, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await productServiceAsync.AddProductAsync(model);
                return RedirectToAction("Index");
            }
            var vendCollection = await vendorServiceAsync.GetAllAsync();
            ViewBag.Vendors = new SelectList(vendCollection, "Id", "Name");
            var cateCollection = await categoryServiceAsync.GetAllAsync();
            ViewBag.Categories = new SelectList(cateCollection, "Id", "Name");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var prodModel = await productServiceAsync.GetProductForEditAsync(id);
            var vendCollection = await vendorServiceAsync.GetAllAsync();
            ViewBag.Vendors = new SelectList(vendCollection, "Id", "Name");
            var cateCollection = await categoryServiceAsync.GetAllAsync();
            ViewBag.Categories = new SelectList(cateCollection, "Id", "Name");
            return View(prodModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductRequestModel model)
        {
            ViewBag.IsEdit = false;
            var vendCollection = await vendorServiceAsync.GetAllAsync();
            ViewBag.Vendors = new SelectList(vendCollection, "Id", "Name");
            var cateCollection = await categoryServiceAsync.GetAllAsync();
            ViewBag.Categories = new SelectList(cateCollection, "Id", "Name");
            if (ModelState.IsValid)
            {
                await productServiceAsync.UpdateProductAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await productServiceAsync.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }
    }
}
