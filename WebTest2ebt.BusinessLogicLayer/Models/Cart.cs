using System;
using System.Collections.Generic;

namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime DateOfBeginingRent { get; set; }
        public DateTime DateOfEndingRent { get; set; }
        public double Cost { get; set; }
        public double? Distance { get; set; }
        public double? Discount { get; set; }
        public List<Equipment> Equipments { get; set; }
        public string Description { get; set; }
        public bool IsNeedDelivery { get; set; }
        public string IdentityBuyerId { get; set; }
        public Buyer Buyer { get; set; }
        public bool IsOrderComplete { get; set; }
    }
}
