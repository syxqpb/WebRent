using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    //[Authorize(Roles = RolesNames.Admin)]
    public class EquipmentController : Controller
    {
        private readonly EquipmentManager _equipmentManager;
        private readonly IPageManager<Equipment> _equipmentPageManager;       
        private readonly ILogger<EquipmentController> _logger;
        private readonly IMapper _mapper;

        public EquipmentController(EquipmentManager equipmentManager, IPageManager<Equipment> equipmentPageManager, ILogger<EquipmentController> logger, IMapper mapper)
        {
            _equipmentManager = equipmentManager;
            _equipmentPageManager = equipmentPageManager;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: Equipment
        public async Task<ActionResult> Index(int pageNumber = 1)
        {
            var equipments = _mapper.Map<IEnumerable<EquipmentViewModel>>(await _equipmentPageManager.GetForPage(pageNumber, 6));
            var photos = _mapper.Map<IEnumerable<EquipmentPhoto>>(await _equipmentPageManager.GetPhotos());

            foreach (var equipment in equipments)
            {
                equipment.equipmentPhotos = photos.Where(item => item.EquipmentId == equipment.Id).ToList();
            }

            return View(new EquipmentsViewModel
            {
                
                Equipments = equipments,
                PageInfo = new PageInfo
                {
                    PageNumber = pageNumber,
                    TotalItems = await _equipmentPageManager.GetCount(),
                    PageSize = 6
                }
            });
        }

        // GET: Equipment/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var photos = await _equipmentPageManager.GetPhotos();

            return View(new EquipmentDetail
            {
                Equipment = await _equipmentManager.GetById(id),
                Photos = photos.Where(item => item.EquipmentId == id).Select(item => item.PathToFile).ToList()
            }) ;
        }
        //Добавить метод где принимиется имя оборудования
        // GET: Equipment/Create
        public async Task<ActionResult> Create()
        {
            var equipmentViewModels = new EquipmentViewModel
            {
            };

            return View(equipmentViewModels);
        }

        // POST: Equipment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Create(EquipmentViewModel equipmentViewModel)
        {
            try
            {
                var equipment = _mapper.Map<Equipment>(equipmentViewModel);
                await _equipmentManager.Add(equipment);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Equipment/Edit/5
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Edit(int id)
        {
            var equipment = await _equipmentManager.GetById(id);
            var equipmentViewModel = MapEquipment(equipment);
                    
            return View(equipmentViewModel);
        }

        // POST: Equipment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Edit(int id, EquipmentViewModel equipmentViewModel)
        {
            var equipment = await _equipmentManager.GetById(id);
            try
            {
                equipment.Id = equipmentViewModel.Id;

                await _equipmentManager.Update(equipment);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error occured during editing product. Exception: {exception.Message}");
                return View(equipmentViewModel);
            }
        }

        // GET: Equipment/Delete/5
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Delete(int id)
        {
            var equipment = await _equipmentManager.GetById(id);
            return View(equipment);
        }

        // POST: Equipment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Delete(EquipmentViewModel equipmentViewModel)
        {
            try
            {
                await _equipmentManager.Delete(equipmentViewModel.Id);

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
