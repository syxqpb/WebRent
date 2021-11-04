using System;
using System.Collections.Generic;
using System.Text;
using WebTest2ebt.DataAccessLayer.Models.Identity;

namespace WebTest2ebt.DataAccessLayer.Models
{
    public class RentHistoryDto
    {
        public int Id { get; set; }
        public DateTime? DateOfBeginingRent { get; set; }
        public DateTime? DateOfEndingRent { get; set; }
        public double? Distance { get; set; }
        public double? Discount { get; set; }
        public double Сost { get; set; }
        public List<CartDto> Carts { get; set; }
        public string Description { get; set; }
        public bool IsNeedDelivery { get; set; }
        public string IdentityBuyerId { get; set; }
        public IdentityBuyer Buyer { get; set; }
        public bool IsOrderComplete { get; set; }
        public string CartName { get; set; }
        public bool IsBack { get; set; }
    }
}
