using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest2ebt.UI.Models
{
    public class EquipmentsViewModel
    {
        public IEnumerable<EquipmentViewModel> Equipments { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
