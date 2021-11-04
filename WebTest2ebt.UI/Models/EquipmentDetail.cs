using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.UI.Models
{
    public class EquipmentDetail
    {
        public Equipment Equipment { get; set; }
        public List<string> Photos { get; set; }
    }
}
