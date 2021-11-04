using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Interfaces;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.BusinessLogicLayer.Validation;
using WebTest2ebt.DataAccessLayer.Models;
using WebTest2ebt.DataAccessLayer.Models.Identity;
using WebTest2ebt.DataAccessLayer.Repositories;

namespace WebTest2ebt.BusinessLogicLayer.Managers
{
    public class BuyerManager : IPageManager<Cart>
    {
        private readonly IRepository<IdentityBuyer> _items;
        private readonly IRepository<IdentityBuyer> _cartRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Buyer> _validator;

        public BuyerManager(IRepository<IdentityBuyer> items, IRepository<IdentityBuyer> cartRepository, IMapper mapper, IValidator<Buyer> validator)
        {
            _items = items;
            _cartRepository = cartRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task Add(Buyer buyer)
        {
            var buyerDto = _mapper.Map<IdentityBuyer>(buyer);

            if (!_validator.Validate(buyer))
            {
                throw new ValidationException($"{nameof(buyer)} has invalid data");
            }

            await _items.Create(buyerDto);
            buyer.Id = buyerDto.Id;
        }

        public async Task Delete(string id)
        {
            var buyer = await _items.FindItem(item => item.Id == id);

            if (buyer is null)
            {
                throw new NullReferenceException("Battery not found");
            }
            else
            {
                await _items.Remove(buyer);

            }
        }

        public async Task Update(Buyer buyer)
        {
            var buyerDto = _mapper.Map<IdentityBuyer>(buyer);

            if (!_validator.Validate(buyer))
            {
                throw new ValidationException($"{nameof(buyer)} has invalid data");
            }

            await _items.Update(buyerDto);
        }

        public async Task<IEnumerable<Buyer>> GetAll()
        {
            return _mapper.Map<IEnumerable<Buyer>>(await _items.Get());
        }

        public async Task<Buyer> GetById(string id)
        {
            return _mapper.Map<Buyer>(await _items.FindItem(item => item.Id == id));
        }
        public async Task<Buyer> GetUser(string id)
        {
            return _mapper.Map<Buyer>(await _cartRepository.GetUser(id));

        }

        public async Task<Buyer> SendFeedback(string buyerId)
        {
            //if (!_validator.Validate(buyer))
            //{
            //    throw new ValidationException($"{nameof(buyer)} has invalid data");
            //}

            //await _items.Create(buyerDto);
            //buyer.Id = buyerDto.Id;
            return _mapper.Map<Buyer>(await _cartRepository.GetUser(buyerId));
        }

        public Task<IEnumerable<Cart>> GetForPage(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EquipmentPhoto>> GetPhotos()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Equipment>> GetCartEquipments(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddEquipmentToCart(int cartId, int equipmentId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveEquipmentFromCart(int cartId, int equipmentId, string returnUrl)
        {
            //var cart = await _items.GetCart(cartId);
            //var equipmentDel = await _cartRepository.FindItem(item => item.Id == equipmentId); //
            //var eq = cart.Equipments.Where(item => item.Id == equipmentDel.Id);
            ////var equipment = await _items.FindItem(item => item.Id == equipmentId);
            //if (cart is null || eq is null)
            //{
            //    throw new NullReferenceException();
            //}
            //else if (eq is CameraDto)
            //{
            //    cart.Equipments.Remove(eq as CameraDto);
            //    await _items.Save();
            //}
            //else if (eq is LensDto)
            //{
            //    cart.Equipments.Remove(eq as LensDto);
            //    await _items.Save();
            //}
            //else if (eq is FlashBulbDto)
            //{
            //    cart.Equipments.Remove(eq as FlashBulbDto);
            //    await _items.Save();
            //}
            //else if (eq is BatteryDto)
            //{
            //    cart.Equipments.Remove(eq as BatteryDto);
            //    await _items.Save();
            //}
            //else if (eq is MicrophoneDto)
            //{
            //    cart.Equipments.Remove(eq as MicrophoneDto);
            //    await _items.Save();
            //}
            //else
            //{
            //    cart.Equipments.Remove(eq);
            //    await _items.Save();
            //}
        }

        public Task CreateOrder(Cart cart, DateTime startRent, DateTime endRent, bool isNeedDelivery, string description)
        {
            throw new NotImplementedException();
        }
    }
}
