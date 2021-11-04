using System.Collections.Generic;

namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Equipment> Equipments { get; set; }
    }
}
