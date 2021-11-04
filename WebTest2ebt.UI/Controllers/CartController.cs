using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Interfaces;
using WebTest2ebt.BusinessLogicLayer.Managers;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.DataAccessLayer.Models.Identity;
using WebTest2ebt.UI.Models;

namespace WebTest2ebt.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly UserManager<IdentityBuyer> _buyerManager;
        private readonly IPageManager<Cart> _cartManager;
        private readonly IPageManager<Equipment> _equipmentPageManager;
        private readonly EquipmentManager _equipmentManager;

        public CartController(ILogger<CartController> logger, UserManager<IdentityBuyer> buyerManager,
                              IPageManager<Cart> cartManager, IPageManager<Equipment> equipmentPageManager,
                              EquipmentManager equipmentManager)
        {
            _logger = logger;
            _buyerManager = buyerManager;
            _cartManager = cartManager;
            _equipmentPageManager = equipmentPageManager;
            _equipmentManager = equipmentManager;
        }



        // GET: CartController
        public async Task<IActionResult> Index(string returnUrl) {
            var user = await _buyerManager.FindByNameAsync(User.Identity.Name);
            var userCart = await _cartManager.GetUser(user.Id);
            var cart = userCart.Carts.Where(item => !item.IsOrderComplete).FirstOrDefault();
            var equipments = await _equipmentManager.GetCartEquipments(cart.Id);
            return View(new CartViewModel {
                Cart = cart,
                Equipments = equipments,
                Id = cart.Id,
                ReturnUrl = returnUrl
                        } ) ;
        }

        // GET: CartController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(Cart cart)
        {
            var user = await _buyerManager.FindByNameAsync(User.Identity.Name);
            var userCart = await _cartManager.GetUser(user.Id);
            var cartModel = userCart.Carts.Where(item => !item.IsOrderComplete /*&& item.Id == cartId*/).FirstOrDefault();
            var equipments = await _equipmentManager.GetCartEquipments(cartModel.Id);
            await _equipmentManager.AddEquipmentFromCartToLogEquip(cartModel.Id, equipments.ToList()); //
            if (cart.IsNeedDelivery)
            {
                cart.Cost += 15;

            }
            else
            {

            }
            await _cartManager.CreateOrder(cartModel, cartModel.DateOfBeginingRent, cartModel.DateOfEndingRent, cartModel.IsNeedDelivery, cartModel.Description);
            //cartModel.
            return View();
        }


        public async Task<IActionResult> RemoveFromCart(int cartId, int equipmentId, string returnUrl)
        {
            var user = await _buyerManager.FindByNameAsync(User.Identity.Name);
            var userCart = await _cartManager.GetUser(user.Id);
            var cart = userCart.Carts.Where(item => !item.IsOrderComplete /*&& item.Id == cartId*/).FirstOrDefault();
            await _equipmentManager.RemoveEquipmentFromCart(cart.Id, equipmentId, returnUrl);
            var equipments = await _equipmentManager.GetCartEquipments(cart.Id);
            //var equipment = _cartManager.GetCartEquipments(equipmentId);

            //return View(new CartViewModel { Cart = cart, Equipments = equipments, Id = cart.Id });

            return RedirectToAction("Cart", "Home");

        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        
        // GET: CartController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
