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
    public class StorageManager : IManager<Storage>
    {
        private readonly IRepository<StorageDto> _items;
        private readonly IMapper _mapper;
        private readonly IValidator<Storage> _validator;

        public StorageManager(IMapper mapper, IValidator<Storage> storageValidator, IRepository<StorageDto> items)
        {
            _mapper = mapper;
            _validator = storageValidator;
            _items = items;
        }

        public async Task Add(Storage storage)
        {
            var storageDto = _mapper.Map<StorageDto>(storage);

            if (!_validator.Validate(storage))
            {
                throw new ValidationException($"{nameof(storage)} has invalid data");
            }

            await _items.Create(storageDto);

            storage.Id = storageDto.Id;
        }

        public async Task Delete(int id)
        {
            var storage = await _items.FindItem(item => item.Id == id);

            if (storage is null)
            {
                throw new NullReferenceException("Battery not found");
            }
            else
            {
                await _items.Remove(storage);

            }
        }

        public async Task Update(Storage storage)
        {
            var storageDto = _mapper.Map<StorageDto>(storage);

            if (!_validator.Validate(storage))
            {
                throw new ValidationException($"{nameof(storage)} has invalid data");
            }

            await _items.Update(storageDto);
        }

        public async Task<IEnumerable<Storage>> GetAll()
        {
            return _mapper.Map<IEnumerable<Storage>>(await _items.Get());
        }

        public async Task<Storage> GetById(int id)
        {
            return _mapper.Map<Storage>(await _items.FindItem(item => item.Id == id));
        }
    }
}
