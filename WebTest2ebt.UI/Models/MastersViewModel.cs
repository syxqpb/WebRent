using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.UI.Models
{
    public class MastersViewModel
    {
        public IEnumerable<MasterViewModel> Masters { get; set; }
        public PageInfo PageInfo { get; set; }
        public List<PhotoAndVideo> PhotosAndVideos { get; set; }
    }
}
