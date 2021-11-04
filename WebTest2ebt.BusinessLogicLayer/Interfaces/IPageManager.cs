using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.BusinessLogicLayer.Interfaces
{
    public interface IPageManager<T> where T : class
    {
        Task<IEnumerable<T>> GetForPage(int pageNumber, int pageSize);
        Task<int> GetCount();
        Task<IEnumerable<EquipmentPhoto>> GetPhotos();
        Task<Buyer> GetUser(string id);
        Task<IEnumerable<Equipment>> GetCartEquipments(int id);
        Task AddEquipmentToCart(int cartId, int equipmentId);
        Task RemoveEquipmentFromCart(int cartId, int equipmentId, string returnUrl);
        Task CreateOrder(Cart cart, DateTime startRent, DateTime endRent, bool isNeedDelivery, string description);
    }
}
