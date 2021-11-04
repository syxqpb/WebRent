using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.BusinessLogicLayer.Interfaces
{

    public interface IPageMasterManager<T> where T : class
    {
        Task<IEnumerable<T>> GetForPage(int pageNumber, int pageSize);
        Task<int> GetCount();
        Task<IEnumerable<PhotoAndVideo>> GetMasterPhotosAndVideo();
        
    }
}
