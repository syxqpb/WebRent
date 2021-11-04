using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Interfaces;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.BusinessLogicLayer.Validation;
using WebTest2ebt.DataAccessLayer.Models;
using WebTest2ebt.DataAccessLayer.Repositories;

namespace WebTest2ebt.BusinessLogicLayer.Managers
{
     public class MasterManager : IManager<Master>, IPageMasterManager<Master>
    {
        private readonly IRepository<MasterDto> _items;
        private readonly IMapper _mapper;
        private readonly IValidator<Master> _validator;
        private readonly IRepository<PhotoAndVideoDto> _photoAndVideo;

        public MasterManager(IRepository<MasterDto> items,
                                  IMapper mapper,
                                  IValidator<Master> validator,
                                  IRepository<PhotoAndVideoDto> photoAndVideo)
        {
            _items = items;
            _mapper = mapper;
            _validator = validator;
            _photoAndVideo = photoAndVideo;
        }

        public async Task Add(Master order)
        {
            var orderDto = _mapper.Map<MasterDto>(order);

            if (!_validator.Validate(order))
            {
                throw new ValidationException($"{nameof(order)} has invalid data");
            }

            await _items.Create(orderDto);
            order.Id = orderDto.Id;
        }

        public async Task Delete(int id)
        {
            var orderMaster = await _items.FindItem(item => item.Id == id);

            if (orderMaster is null)
            {
                throw new NullReferenceException("Battery not found");
            }
            else
            {
                await _items.Remove(orderMaster);

            }
        }

        public async Task Update(Master order)
        {
            var orderDto = _mapper.Map<MasterDto>(order);

            if (!_validator.Validate(order))
            {
                throw new ValidationException($"{nameof(order)} has invalid data");
            }

            await _items.Update(orderDto);
        }

        public async Task<IEnumerable<Master>> GetAll()
        {
            return _mapper.Map<IEnumerable<Master>>(await _items.Get());
        }

        public async Task<Master> GetById(int id)
        {
            return _mapper.Map<Master>(await _items.FindItem(item => item.Id == id));
        }
        public async Task<IEnumerable<Master>> GetForPage(int pageNumber, int pageSize)
        {
            return _mapper.Map<IEnumerable<Master>>(await _items.GetForPage(pageNumber, pageSize));
        }
        public async Task<int> GetCount()
        {
            return await _items.GetCount();
        }
        public async Task<IEnumerable<PhotoAndVideo>> GetMasterPhotosAndVideo()
        {
            return _mapper.Map<IEnumerable<PhotoAndVideo>>(await _photoAndVideo.Get());
        }
        
    }
}
