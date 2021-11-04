using System;

namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class OrderMaster
    {
        public int Id { get; set; }
        public DateTime DateOfTheEvent { get; set; }
        public int MasterId { get; set; }
        public string IdentityBuyerId { get; set; }

        public Master Master { get; set; }
        public Buyer Buyer { get; set; }

    }
}
