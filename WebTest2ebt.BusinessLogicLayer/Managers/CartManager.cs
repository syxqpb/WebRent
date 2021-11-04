using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.BusinessLogicLayer.Validation;
using WebTest2ebt.DataAccessLayer.Models;
using WebTest2ebt.DataAccessLayer.Repositories;

namespace WebTest2ebt.BusinessLogicLayer.Managers
{
    public class CartManager : IManager<Cart>
    {
        private readonly IRepository<CartDto> _items;
        private readonly IRepository<RentHistoryDto> _rentHistoryRep;
        private readonly IRepository<EquipmentLogDto> _equipmentLogRep;
        private readonly IMapper _mapper;
        private readonly IValidator<Cart> _validator;

        public CartManager(IRepository<CartDto> items, IRepository<RentHistoryDto> rentHistoryRep,
                           IRepository<EquipmentLogDto> equipmentLogRep, IMapper mapper, IValidator<Cart> validator)
        {
            _items = items;
            _rentHistoryRep = rentHistoryRep;
            _equipmentLogRep = equipmentLogRep;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task Add(Cart category)
        {
            var categoryDto = _mapper.Map<CartDto>(category);

            if (!_validator.Validate(category))
            {
                throw new ValidationException($"{nameof(category)} has invalid data");
            }

            await _items.Create(categoryDto);

            category.Id = categoryDto.Id;
        }

        public async Task Delete(int id)
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

        public async Task Update(Cart category)
        {
            var categoryDto = _mapper.Map<CartDto>(category);

            if (!_validator.Validate(category))
            {
                throw new ValidationException($"{nameof(category)} has invalid data");
            }

            await _items.Update(categoryDto);
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            return _mapper.Map<IEnumerable<Cart>>(await _items.Get());
        }
        public async Task<IEnumerable<Cart>> CreateOrder(Cart cart, DateTime startRent, DateTime endRent, bool isNeedDelivery, string description)
        {
            var getCart = await _items.GetCart(cart.Id);
            
            var equipments = await _items.Get();
            //var asdas = await _equipmentLogRep.CreateRange(getCart.Equipments.Where(item => item.Id = cart.Equipments.Where(i=>i.Id == )));
            await _rentHistoryRep.Create(new RentHistoryDto { CartName = cart.Id.ToString(), DateOfBeginingRent = startRent,
                DateOfEndingRent = endRent, IsNeedDelivery = isNeedDelivery, Description = description, Сost = cart.Cost });
            return _mapper.Map<IEnumerable<Cart>>(await _items.Get());
        }
        public async Task<Cart> GetById(int id)
        {
            return _mapper.Map<Cart>(await _items.FindItem(item => item.Id == id));
        }
    }
}