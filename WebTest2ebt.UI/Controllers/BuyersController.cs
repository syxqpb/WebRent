using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Managers;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.DataAccessLayer.Models.Identity;
using WebTest2ebt.UI.AppConfiguration;
using WebTest2ebt.UI.Models;

namespace WebTest2ebt.UI.Controllers
{
    [Authorize(Roles = RolesNames.AdminOrUser)]
    public class BuyersController : Controller
    {
        private readonly BuyerManager _buyerManager;
        private readonly IManager<Cart> _cartManager;
        private readonly ILogger<BuyersController> _logger;
        private readonly UserManager<IdentityBuyer> _userManager;
        private readonly IMapper _mapper;

        public BuyersController(
            BuyerManager buyerManager,
            IManager<Cart> cartManager,
            ILogger<BuyersController> logger,
            UserManager<IdentityBuyer> userManager,
            IMapper mapper)
        {
            _buyerManager = buyerManager;
            _cartManager = cartManager;
            _logger = logger;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }
        public async Task<ActionResult> HistoryDetail()
        {
            return View();
        }
        public async Task<ActionResult> EditProfile()
        {
            return View();
        }

        public async Task<ActionResult> EditPassword()
        {
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> Details()
        //{
        //    var buyerId = (await _userManager.GetUserAsync(User));

        //    var buyer = await _buyerManager.GetById(buyerId.Id);

        //    var buyerViewModel = _mapper.Map<Buyer, BuyerViewModel>(buyer);

        //    return View(buyerViewModel);
        //}

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BuyerViewModel buyerViewModel)
        {
            try
            {
                var buyer = _mapper.Map<BuyerViewModel, Buyer>(buyerViewModel);

                await _buyerManager.Add(buyer);

                var user = await _userManager.GetUserAsync(User);

                var cart = new Cart {IdentityBuyerId = user.Id, IsOrderComplete = false };

                await _cartManager.Add(cart);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error occured during creating buyer. Exception: {exception.Message}");
                return View(buyerViewModel);
            }
        }
        
        //[HttpGet]
        //public async Task<IActionResult> Edit()
        //{
        //    var buyerId = (await _userManager.GetUserAsync(User));

        //    var buyer = await _buyerManager.GetById(buyerId.Id);

        //    var buyerViewModel = _mapper.Map<Buyer, BuyerViewModel>(buyer);

        //    return View(buyerViewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(BuyerViewModel buyerViewModel)
        //{
        //    try
        //    {
        //        var buyer = _mapper.Map<BuyerViewModel, Buyer>(buyerViewModel);

        //        await _buyerManager.Update(buyer);

        //        return RedirectToAction("Index", "Home");
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.LogError($"Error occured during updating buyer. Exception: {exception.Message}");
        //        return View(buyerViewModel);
        //    }
        //}

        
    }
}
