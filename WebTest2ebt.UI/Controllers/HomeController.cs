using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Interfaces;
using WebTest2ebt.BusinessLogicLayer.Managers;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.DataAccessLayer.Models.Identity;
using WebTest2ebt.UI.Models;

namespace WebTest2ebt.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityBuyer> _buyerManager;
        private readonly IPageManager<Cart> _cartManager;
        private readonly IPageManager<Equipment> _equipmentManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityBuyer> buyerManager, IPageManager<Cart> cartManager, IPageManager<Equipment> equipmentManager)
        {
            _logger = logger;
            _buyerManager = buyerManager;
            _cartManager = cartManager;
            _equipmentManager = equipmentManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Reviews()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            return View("Login");
        }
        [Authorize]
        public async Task<IActionResult> AddToCart(int equipmentId)
        {
            //try
            //{
                var user = await _buyerManager.FindByNameAsync(User.Identity.Name);
                var userCart = await _cartManager.GetUser(user.Id);
                var cart = userCart.Carts.Where(item => !item.IsOrderComplete).FirstOrDefault();
                await _equipmentManager.AddEquipmentToCart(cart.Id,equipmentId);
            //}
            //catch
            //{

            //}
            return RedirectToAction("Cart", "Home");
        }
        
        [Authorize]
        public async Task<IActionResult> Cart()
        {
            //
            var user = await _buyerManager.FindByNameAsync(User.Identity.Name);
            var userCart = await _cartManager.GetUser(user.Id);
            var cart = userCart.Carts.Where(item => !item.IsOrderComplete).FirstOrDefault();
            var equipments = await _equipmentManager.GetCartEquipments(cart.Id);
            
            //var b = await _rentManager.GetAll();
            //получить модель как во вью
            //var a = new CartViewModel
            //{
            //    Rents = b.Where(item => item.CartId == user.CartId).ToList()
            //};
            return View(new CartViewModel { Cart = cart, Equipments = equipments, Id = cart.Id });
        }
       //public async Task
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendFeedback(Feedback feedback)
        {
            var user = await _buyerManager.FindByNameAsync(User.Identity.Name);
            //await _buyerManager;
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
