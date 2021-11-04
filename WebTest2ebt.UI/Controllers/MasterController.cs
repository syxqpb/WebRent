using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Interfaces;
using WebTest2ebt.BusinessLogicLayer.Managers;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.UI.AppConfiguration;
using WebTest2ebt.UI.Models;

namespace WebTest2ebt.UI.Controllers
{
    public class MasterController : Controller
    {
        private readonly MasterManager _masterManager;
        private readonly IPageMasterManager<Master> _masterPageManager;
        private readonly ILogger<MasterController> _logger;
        private readonly IMapper _mapper;

        public MasterController(MasterManager masterManager, IPageMasterManager<Master> masterPageManager, ILogger<MasterController> logger, IMapper mapper)
        {
            _masterManager = masterManager;
            _masterPageManager = masterPageManager;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: MasterController
        public async Task<ActionResult> Index(int pageNumber = 1)
        {
            var masters = _mapper.Map<IEnumerable<MasterViewModel>>(await _masterPageManager.GetForPage(pageNumber, 6));
            var photos = _mapper.Map<IEnumerable<PhotoAndVideo>>(await _masterPageManager.GetMasterPhotosAndVideo());

            foreach (var master in masters)
            {
                master.PhotosAndVideos = photos.Where(item => item.MasterId == master.Id).ToList();
            }

            return View(new MastersViewModel
            {

                Masters = masters,
                PageInfo = new PageInfo
                {
                    PageNumber = pageNumber,
                    TotalItems = await _masterPageManager.GetCount(),
                    PageSize = 6
                }
            });
        }

        // GET: MasterController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var photos = await _masterPageManager.GetMasterPhotosAndVideo();

            return View(new MasterDetail
            {
                Master = await _masterManager.GetById(id),
                Photos = photos.Where(item => item.MasterId == id).Select(item => item.PathToFile).ToList()
            });
        }

        // GET: MasterController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: MasterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterViewModel masterViewModel)
        {
            try
            {
                var master = _mapper.Map<Master>(masterViewModel);
                await _masterManager.Add(master);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var master = await _masterManager.GetById(id);
            //var equipmentViewModel = MapEquipment(equipment);

            return View(/*equipmentViewModel*/);
        }

        // POST: MasterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Edit(int id, MasterViewModel masterViewModel)
        {
            var master = await _masterManager.GetById(id);
            try
            {
                master.Id = masterViewModel.Id;

                await _masterManager.Update(master);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error occured during editing product. Exception: {exception.Message}");
                return View(masterViewModel);
            }
        }

        // GET: MasterController/Delete/5
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Delete(int id)
        {
            var master = await _masterManager.GetById(id);
            return View(master);
        }

        // POST: MasterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Delete(MasterViewModel masterViewModel)
        {
            try
            {
                await _masterManager.Delete(masterViewModel.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private EquipmentViewModel MapEquipment(Equipment equipment)
        {
            return _mapper.Map<Equipment, EquipmentViewModel>(equipment,
                                                      options => options.AfterMap((src, dest) =>
                                                      {
                                                          dest.Name = src.Name;
                                                          dest.ReceiptDate = src.ReceiptDate;
                                                          dest.WriteOffDate = src.WriteOffDate;
                                                          dest.Сondition = src.Сondition;

                                                      }));
        }
    }
}
