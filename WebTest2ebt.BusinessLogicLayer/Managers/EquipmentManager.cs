using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Interfaces;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.BusinessLogicLayer.Validation;
using WebTest2ebt.DataAccessLayer.Models;
using WebTest2ebt.DataAccessLayer.Repositories;

namespace WebTest2ebt.BusinessLogicLayer.Managers
{
    public class EquipmentManager : IManager<Equipment>, IPageManager<Equipment>
    {
        private readonly IRepository<EquipmentDto> _items;
        private readonly IMapper _mapper;
        private readonly IValidator<Equipment> _validator;
        private readonly IRepository<EquipmentPhotoDto> _equipmentPhoto;
        private readonly IRepository<CartDto> _cartRepository;
        private readonly IRepository<EquipmentLogDto> _equipmentLogRepository;
        private readonly IRepository<StorageDto> _storageLogRepository;

        public EquipmentManager(IRepository<EquipmentDto> items, IMapper mapper, IValidator<Equipment> validator,
                                IRepository<EquipmentPhotoDto> equipmentPhoto, IRepository<CartDto> cartRepository,
                                IRepository<EquipmentLogDto> equipmentLogRepository,
                                IRepository<StorageDto> storageLogRepository)
        {
            _items = items;
            _mapper = mapper;
            _validator = validator;
            _equipmentPhoto = equipmentPhoto;
            _cartRepository = cartRepository;
            _equipmentLogRepository = equipmentLogRepository;
            _storageLogRepository = storageLogRepository;
        }

        public async Task Add(Equipment category)
        {
            var categoryDto = _mapper.Map<EquipmentDto>(category);

            if (!_validator.Validate(category))
            {
                throw new ValidationException($"{nameof(category)} has invalid data");
            }

            await _items.Create(categoryDto);

            category.Id = categoryDto.Id;
        }

        public async Task Delete(int id)
        {
            var equipment = await _items.FindItem(item => item.Id == id);

            if (equipment is null)
            {
                throw new NullReferenceException("Battery not found");
            }
            else
            {
                await _items.Remove(equipment);

            }
        }

        public async Task Update(Equipment category)
        {
            var categoryDto = _mapper.Map<EquipmentDto>(category);

            if (!_validator.Validate(category))
            {
                throw new ValidationException($"{nameof(category)} has invalid data");
            }

            await _items.Update(categoryDto);
        }

        public async Task<IEnumerable<Equipment>> GetAll()
        {
            return _mapper.Map<IEnumerable<Equipment>>(await _items.Get());
        }

        public async Task<Equipment> GetById(int id)
        {
            var equipment = await _items.FindItem(item => item.Id == id);

            if (equipment is null)
            {
                throw new NullReferenceException();
            }
            else
            {
                if (equipment is CameraDto)
                {
                    return _mapper.Map<Camera>(equipment as CameraDto);
                }
                else if (equipment is LensDto)
                {
                    return _mapper.Map<Lens>(equipment as LensDto);
                }
                else if (equipment is BatteryDto)
                {
                    return _mapper.Map<Battery>(equipment as BatteryDto);
                }
                else if (equipment is FlashBulbDto)
                {
                    return _mapper.Map<FlashBulb>(equipment as FlashBulbDto);
                }
                else if (equipment is MicrophoneDto)
                {
                    return _mapper.Map<Microphone>(equipment as MicrophoneDto);
                }
                else
                {
                    return _mapper.Map<Equipment>(equipment);
                }

            }
        }

        public async Task<IEnumerable<Equipment>> GetForPage(int pageNumber, int pageSize)
        {
            return _mapper.Map<IEnumerable<Equipment>>(await _items.GetForPage(pageNumber, pageSize));
        }
        public async Task<int> GetCount()
        {
            return await _items.GetCount();
        }
        public async Task<IEnumerable<EquipmentPhoto>> GetPhotos()
        {
            return _mapper.Map<IEnumerable<EquipmentPhoto>>(await _equipmentPhoto.Get());
        }

        public Task<Buyer> GetUser(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Equipment>> GetCartEquipments(int id)
        {
            var cart = await _items.GetCart(id);
            return _mapper.Map<IEnumerable<Equipment>>(cart.Equipments);
        }
        
        public async Task AddEquipmentToCart(int cartId, int equipmentId)
        {
            var cart = await _items.GetCart(cartId);
            var equipment = await _items.FindItem(item => item.Id == equipmentId);
            if (cart is null || equipment is null)
            {
                throw new NullReferenceException();
            }
            else if(equipment is CameraDto)
            {              
                cart.Equipments.Add(equipment as CameraDto);
                await _items.Save();
            }
            else if (equipment is LensDto)
            {
                cart.Equipments.Add(equipment as LensDto);
                await _items.Save();
            }
            else if (equipment is FlashBulbDto)
            {
                cart.Equipments.Add(equipment as FlashBulbDto);
                await _items.Save();
            }
            else if (equipment is BatteryDto)
            {
                cart.Equipments.Add(equipment as BatteryDto);
                await _items.Save();
            }
            else if (equipment is MicrophoneDto)
            {
                cart.Equipments.Add(equipment as MicrophoneDto);
                await _items.Save();
            }
            else
            {
                cart.Equipments.Add(equipment);
                await _items.Save();
            }
        }
        public async Task RemoveEquipmentFromCart(int cartId, int equipmentId, string returnUrl) // equipmentId берётся не из Оборудования, а из корзины
        {
            var cart = await _items.GetCart(cartId);
            var equipmentDel = await _items.FindItem(item => item.Id == equipmentId); //
            var eq = cart.Equipments.Where(item => item.Id == equipmentDel.Id);
            //var equipment = await _items.FindItem(item => item.Id == equipmentId);
            if (cart is null || equipmentDel is null)
            {
                throw new NullReferenceException();
            }
            else
            {
                cart.Equipments = cart.Equipments.Where(i => i.Id != equipmentDel.Id).ToList();
                await _items.Save();
            }

        }
        public async Task AddEquipmentFromCartToLogEquip(int cartId, List<Equipment> equipments)
        {
            var cart = await _items.GetCart(cartId);
            //var equipLog = await _equipmentLogRepository.CreateRange();
            var storage = await _storageLogRepository.Get();
            //var equip = equipments.Where(i => i.Id == cart);
            await _equipmentLogRepository.CreateRange(equipments.Select(item => new EquipmentLogDto { Manufacturer = item.Manufacturer, Model = item.Model, Name = item.Name, Сost = item.Сost, Type = item.Type, StorageName = storage.First().Id }));

            if (cart is null)
            {
                throw new NullReferenceException();
            }
            else
            {
               // cart.Equipments = cart.Equipments.Where(i => i.Id != equipmentDel.Id).ToList();
                await _items.Save();
            }

        }
        public Task CreateOrder(Cart cart, DateTime startRent, DateTime endRent, bool isNeedDelivery, string description)
        {
            throw new NotImplementedException();
        }
    }
}
