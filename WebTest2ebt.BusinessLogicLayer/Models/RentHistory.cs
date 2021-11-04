using System;
using System.Collections.Generic;
using System.Text;

namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class RentHistory
    {
        public int Id { get; set; }
        public DateTime? DateOfBeginingRent { get; set; }
        public DateTime? DateOfEndingRent { get; set; }
        public double? Distance { get; set; }
        public double? Discount { get; set; }
        public double Сost { get; set; }
        public List<Cart> Carts { get; set; }
        public string Description { get; set; }
        public bool IsNeedDelivery { get; set; }
        public string IdentityBuyerId { get; set; }
        public Buyer Buyer { get; set; }
        public string CartName { get; set; }
        public bool IsBack { get; set; }
    }
}
