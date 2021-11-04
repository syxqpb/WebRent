using System;
using System.Collections.Generic;
using System.Text;

namespace WebTest2ebt.DataAccessLayer.Models
{
    public class EquipmentPhotoDto
    {
        public int Id { get; set; }
        public string PathToFile { get; set; }
        public int EquipmentId { get; set; }

        public EquipmentDto Equipment { get; set; }
    }
}
