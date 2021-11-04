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
    public class MicrophoneManager : IManager<Microphone>
    {
        private readonly IRepository<MicrophoneDto> _items;
        private readonly IMapper _mapper;
        private readonly IValidator<Microphone> _validator;

        public MicrophoneManager(IMapper mapper, IValidator<Microphone> categoryValidator, IRepository<MicrophoneDto> items)
        {
            _mapper = mapper;
            _validator = categoryValidator;
            _items = items;
        }

        public async Task Add(Microphone category)
        {
            var categoryDto = _mapper.Map<MicrophoneDto>(category);

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

        public async Task Update(Microphone category)
        {
            var categoryDto = _mapper.Map<MicrophoneDto>(category);

            if (!_validator.Validate(category))
            {
                throw new ValidationException($"{nameof(category)} has invalid data");
            }

            await _items.Update(categoryDto);
        }

        public async Task<IEnumerable<Microphone>> GetAll()
        {
            return _mapper.Map<IEnumerable<Microphone>>(await _items.Get());
        }

        public async Task<Microphone> GetById(int id)
        {
            return _mapper.Map<Microphone>(await _items.FindItem(item => item.Id == id));
        }
    }
}
