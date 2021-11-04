using WebTest2ebt.BusinessLogicLayer.Models;
using WebTest2ebt.DataAccessLayer.Models;
using WebTest2ebt.DataAccessLayer.Models.Identity;
using AutoMapper;

namespace WebTest2ebt.BusinessLogicLayer.Mapper
{
    public class PhotoRentProfile : Profile
    {
        public PhotoRentProfile()
        {
            CreateMap<Battery, BatteryDto>().ReverseMap();

            CreateMap<Camera, CameraDto>().ReverseMap();

            CreateMap<Cart, CartDto>().ReverseMap();

            CreateMap<Equipment, EquipmentDto>().ReverseMap();

            CreateMap<EquipmentPhoto, EquipmentPhotoDto>().ReverseMap();

            CreateMap<FlashBulb, FlashBulbDto>().ReverseMap();

            CreateMap<Lens, LensDto>().ReverseMap();

            CreateMap<Master, MasterDto>().ReverseMap();

            CreateMap<Microphone, MicrophoneDto>().ReverseMap();

            CreateMap<OrderMaster, OrderMasterDto>().ReverseMap();

            CreateMap<PhotoAndVideo, PhotoAndVideoDto>().ReverseMap();

            //CreateMap<Portfolio, PortfolioDto>().ReverseMap();

            CreateMap<Service, ServiceDto>().ReverseMap();

            CreateMap<Storage, StorageDto>().ReverseMap();

            CreateMap<Feedback, FeedbackDto>().ReverseMap();

            CreateMap<Buyer, IdentityBuyer>().ReverseMap();

            CreateMap<RentHistory, RentHistoryDto>().ReverseMap();

            CreateMap<EquipmentLog, EquipmentLogDto>().ReverseMap();

        }
    }
}
