using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServiceAsync orderServiceAsync;
        public OrderController(IOrderServiceAsync ord)
        {
            orderServiceAsync = ord;
        }

        public async Task<IActionResult> Index()
        {
            var result = await orderServiceAsync.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                await orderServiceAsync.AddOrderAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var ordModel = await orderServiceAsync.GetOrderForEditAsync(id);
            return View(ordModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrderModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await orderServiceAsync.UpdateOrderAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await orderServiceAsync.DeleteOrderAsync(id);
            return RedirectToAction("Index");
        }
    }
}
