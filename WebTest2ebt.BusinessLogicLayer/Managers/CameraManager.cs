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
    public class CameraManager : IManager<Camera>
    {
        private readonly IRepository<CameraDto> _items;
        private readonly IMapper _mapper;
        private readonly IValidator<Camera> _validator;

        public CameraManager(IMapper mapper, IValidator<Camera> categoryValidator, IRepository<CameraDto> items)
        {
            _mapper = mapper;
            _validator = categoryValidator;
            _items = items;
        }

        public async Task Add(Camera category)
        {
            var categoryDto = _mapper.Map<CameraDto>(category);

            if (!_validator.Validate(category))
            {
                throw new ValidationException($"{nameof(category)} has invalid data");
            }

            await _items.Create(categoryDto);

            category.Id = categoryDto.Id;
        }

        public async Task Delete(int id)
        {
            var camera = await _items.FindItem(item => item.Id == id);

            if (camera is null)
            {
                throw new NullReferenceException("Battery not found");
            }
            else
            {
                await _items.Remove(camera);

            }
        }

        public async Task Update(Camera category)
        {
            var categoryDto = _mapper.Map<CameraDto>(category);

            if (!_validator.Validate(category))
            {
                throw new ValidationException($"{nameof(category)} has invalid data");
            }

            await _items.Update(categoryDto);
        }

        public async Task<IEnumerable<Camera>> GetAll()
        {
            return _mapper.Map<IEnumerable<Camera>>(await _items.Get());
        }

        public async Task<Camera> GetById(int id)
        {
            return _mapper.Map<Camera>(await _items.FindItem(item => item.Id == id));
        }
    }
}
