using System;
using System.Collections.Generic;
using System.Text;

namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class EquipmentPhoto
    {
        public int Id { get; set; }
        public string PathToFile { get; set; }
        public int EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
