using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.UI.Models;

namespace WebTest2ebt.UI.Mappers
{
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<Buyer, BuyerViewModel>().ReverseMap();
            
            CreateMap<Battery, BatteryViewModel>().ReverseMap();

            CreateMap<Camera, CameraViewModel>().ReverseMap();

            CreateMap<Cart, CartViewModel>().ReverseMap();

            CreateMap<Equipment, EquipmentViewModel>().ReverseMap();

            CreateMap<FlashBulb, FlashBulbViewModel>().ReverseMap();

            CreateMap<Lens, LensViewModel>().ReverseMap();

            CreateMap<Master, MasterViewModel>().ReverseMap();

            CreateMap<MastersViewModel, MasterViewModel>().ReverseMap(); //

            CreateMap<Microphone, MicrophoneViewModel>().ReverseMap();

            CreateMap<OrderMaster, OrderMasterViewModel>().ReverseMap();

            CreateMap<PhotoAndVideo, PhotoAndVideoViewModel>().ReverseMap();

           // CreateMap<Portfolio, PortfolioViewModel>().ReverseMap();

            CreateMap<Service, ServiceViewModel>().ReverseMap();

            CreateMap<Storage, StorageViewModel>().ReverseMap();

            CreateMap<Feedback, FeedbackViewModel>().ReverseMap();

        }
    }
}
