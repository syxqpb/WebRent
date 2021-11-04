using System;
using System.Collections.Generic;
using System.Text;

namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class EquipmentLog
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Сost { get; set; }
        public int StorageName { get; set; }
    }
}
