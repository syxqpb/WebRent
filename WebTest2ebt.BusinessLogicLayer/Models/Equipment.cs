using System;
using System.Collections.Generic;

namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public DateTime? WriteOffDate { get; set; }
        public int Сondition { get; set; }
        public double Сost { get; set; }
        public int CartId { get; set; }
        public int StorageId { get; set; }
        public List<Cart> Carts { get; set; }
        public Storage Storage { get; set; }
        public List<EquipmentPhoto> EquipmentPhotos { get; set; }
        public bool IsTaken { get; set; }
    }
}
