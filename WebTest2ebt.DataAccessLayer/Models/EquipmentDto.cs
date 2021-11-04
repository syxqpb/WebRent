using System;
using System.Collections.Generic;
using System.Text;


namespace WebTest2ebt.DataAccessLayer.Models
{
    public class EquipmentDto
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
        public int StorageId { get; set; }
        public List<CartDto> Carts{ get; set; }
        public StorageDto Storage{ get; set; }
        public List<EquipmentPhotoDto> EquipmentPhotos { get; set; }
        public bool IsTaken { get; set; }
    }
}
