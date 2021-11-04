using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.BusinessLogicLayer.Validation;
using WebTest2ebt.DataAccessLayer.Models;
using WebTest2ebt.DataAccessLayer.Repositories;

namespace WebTest2ebt.BusinessLogicLayer.Managers
{
    public class BatteryManager : IManager<Battery>
    {
        private readonly IRepository<BatteryDto> _items;
        private readonly IMapper _mapper;
        private readonly IValidator<Battery> _validator;

        public BatteryManager(IMapper mapper, IValidator<Battery> categoryValidator, IRepository<BatteryDto> items)
        {
            _mapper = mapper;
            _validator = categoryValidator;
            _items = items;
        }

        public async Task Add(Battery category)
        {
            var categoryDto = _mapper.Map<BatteryDto>(category);

            if (!_validator.Validate(category))
            {
                throw new ValidationException($"{nameof(category)} has invalid data");
            }

            await _items.Create(categoryDto);

            category.Id = categoryDto.Id;
        }

        public async Task Delete(int id)
        {
            var battery = await _items.FindItem(item => item.Id == id);

            if (battery is null)
            {
                throw new NullReferenceException("Battery not found");
            }
            else
            {
                await _items.Remove(battery);

            }
        }

        public async Task Update(Battery category)
        {
            var categoryDto = _mapper.Map<BatteryDto>(category);

            if (!_validator.Validate(category))
            {
                throw new ValidationException($"{nameof(category)} has invalid data");
            }

            await _items.Update(categoryDto);
        }

        public async Task<IEnumerable<Battery>> GetAll()
        {
            return _mapper.Map<IEnumerable<Battery>>(await _items.Get());
        }

        public async Task<Battery> GetById(int id)
        {
            return _mapper.Map<Battery>(await _items.FindItem(item => item.Id == id));
        }
    }
}
