using AutoMapper;
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
    public class OrdersController : Controller
    {
        private readonly BuyerManager _buyerManager;
        private readonly ILogger<OrdersController> _logger;
        private readonly MasterManager _orderMasterManager;
        private readonly UserManager<IdentityBuyer> _userManager;
        private readonly IMapper _mapper;

        public OrdersController(
             BuyerManager buyerManager,
            ILogger<OrdersController> logger,
            MasterManager orderMasterManager,
            UserManager<IdentityBuyer> userManager,
            IMapper mapper)
        {
            _buyerManager = buyerManager;
            _logger = logger;
            _orderMasterManager = orderMasterManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET: OrdersController
        public async Task<IActionResult> Index(OrderMasterViewModel orderMasterViewModel)
        {
            var buyers = await _buyerManager.GetAll();
            var orders = await _orderMasterManager.GetAll();

            if (User.IsInRole(RolesNames.Admin))
            {
                //orderMasterViewModel = orders.Select(order => MapOrder(order, buyers));
                return View(/*orderMasterViewModel*/);
            }
            else
            {
                var buyerId = (await _userManager.GetUserAsync(User));
                //var orderMasterViewModel = orders.Where(order => order.Id == buyerId.Id).Select(order => MapOrder(order, buyers));
                return View();
            }
        }

        // GET: OrdersController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: OrdersController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: OrdersController/Create
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

        // GET: OrdersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: OrdersController/Edit/5
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

        // GET: OrdersController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        // POST: OrdersController/Delete/5
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
        //private OrderMasterViewModel MapOrder(OrderMaster orderMaster, IEnumerable<Buyer> buyers)
        //{
        //    return _mapper.Map<OrderMaster, OrderMasterViewModel>(orderMaster,
        //                                              options => options.AfterMap((src, dest) =>
        //                                              {
        //                                                  //dest.MasterId = buyers.First(buyer => buyer.OrderMasters == orderMaster.MasterId).FirstName;
        //                                                  //dest.ProductName = products.First(product => product.Id == orderMaster.ProductId).Name;
        //                                              }));
        //}
    }
}
