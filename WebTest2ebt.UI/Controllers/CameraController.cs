using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Managers;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.UI.AppConfiguration;
using WebTest2ebt.UI.Models;

namespace WebTest2ebt.UI.Controllers
{
    public class CameraController : Controller
    {
        private readonly IManager<Equipment> _equipmentManager;
        private readonly ILogger<CameraController> _logger;
        private readonly IMapper _mapper;

        public CameraController(IManager<Equipment> equipmentManager, ILogger<CameraController> logger, IMapper mapper)
        {
            _equipmentManager = equipmentManager;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: CameraController
        public async Task<IActionResult> Index()
        {
            //привязать камеры
            var equipmentViewModels = (await _equipmentManager.GetAll())
                                    .Select(equipment => MapEquipment(equipment))
                                    .OrderBy(equipment => equipment.Name);

            return View(equipmentViewModels);
        }

        // GET: CameraController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: CameraController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: CameraController/Create
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

        // GET: CameraController/Edit/5
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Edit(int id)
        {

            //var equipment = await _equipmentManager.GetById(id);
            //var productViewModel = MapCamera(equipment);
            //productViewModel.Fields = MapFields(product, characteristics); ;

            //productViewModel.Categories = new SelectList(await _categoryManager.GetAll(), "Id", "Name");
            //productViewModel.Manufacturers = new SelectList(await _manufacturerManager.GetAll(), "Id", "Name");

            //var emptyFields = characteristics
            //                  .Where(characteristic =>
            //                             characteristic.CategoryId == product.CategoryId &&
            //                             !productViewModel.Fields.Any(field => field.CharacteristicId == characteristic.Id))
            //                  .Select(characteristic => new FieldViewModel
            //                  {
            //                      CharacteristicId = characteristic.Id,
            //                      CharacteristicName = characteristic.Name
            //                  })
            //                  .ToList();

            //productViewModel.Fields = productViewModel.Fields.Union(emptyFields).ToList();

            return View(/*productViewModel*/);
        }

        // POST: CameraController/Edit/5
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

        // GET: CameraController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //привязать камеры
            var equipment = await _equipmentManager.GetById(id);
            return View(equipment);
        }

        // POST: CameraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CameraViewModel cameraViewModel)
        {
            try
            {
                await _equipmentManager.Delete(cameraViewModel.Id);

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
        //private CameraViewModel MapProduct(Equipment equipment)
        //{
        //    return _mapper.Map<Camera, CameraViewModel>(equipment,
        //                                              options => options.AfterMap((src, dest) =>
        //                                              {
        //                                                  dest. = categories
        //                                                                      .First(category => category.Id == product.CategoryId)
        //                                                                      .Name;
        //                                                  dest.ManufacturerName = manufacturers
        //                                                                          .First(manufacturer => manufacturer.Id == product.ManufacturerId)
        //                                                                          .Name;
        //                                              }));
        //}
    }
}
