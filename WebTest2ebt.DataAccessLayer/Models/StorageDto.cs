using System.Collections.Generic;

namespace WebTest2ebt.DataAccessLayer.Models
{
    public class StorageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EquipmentDto> Equipments { get; set; }
    }
}
