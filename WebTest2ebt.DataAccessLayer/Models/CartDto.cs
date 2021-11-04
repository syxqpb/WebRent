using System;
using System.Collections.Generic;
using WebTest2ebt.DataAccessLayer.Models.Identity;

namespace WebTest2ebt.DataAccessLayer.Models
{
    public class CartDto
    {
        public int Id { get; set; }     
        public DateTime DateOfBeginingRent { get; set; }
        public DateTime DateOfEndingRent { get; set; }
        public double Cost { get; set; }
        public double? Distance { get; set; }
        public double? Discount { get; set; }
        public List<EquipmentDto> Equipments { get; set; }
        public string Description { get; set; }
        public bool IsNeedDelivery { get; set; }
        public string IdentityBuyerId { get; set; }
        public IdentityBuyer IdentityBuyer { get; set; }
        public bool IsOrderComplete { get; set; }
    }
}
