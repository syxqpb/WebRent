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
    public class FlashBulbManager : IManager<FlashBulb>
    {
        private readonly IRepository<FlashBulbDto> _items;
        private readonly IMapper _mapper;
        private readonly IValidator<FlashBulb> _validator;

        public FlashBulbManager(IMapper mapper, IValidator<FlashBulb> categoryValidator, IRepository<FlashBulbDto> items)
        {
            _mapper = mapper;
            _validator = categoryValidator;
            _items = items;
        }

        public async Task Add(FlashBulb category)
        {
            var categoryDto = _mapper.Map<FlashBulbDto>(category);

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

        public async Task Update(FlashBulb category)
        {
            var categoryDto = _mapper.Map<FlashBulbDto>(category);

            if (!_validator.Validate(category))
            {
                throw new ValidationException($"{nameof(category)} has invalid data");
            }

            await _items.Update(categoryDto);
        }

        public async Task<IEnumerable<FlashBulb>> GetAll()
        {
            return _mapper.Map<IEnumerable<FlashBulb>>(await _items.Get());
        }

        public async Task<FlashBulb> GetById(int id)
        {
            return _mapper.Map<FlashBulb>(await _items.FindItem(item => item.Id == id));
        }
    }
}
