using System;

using WebTest2ebt.DataAccessLayer.Models.Identity;

namespace WebTest2ebt.DataAccessLayer.Models
{
    public class OrderMasterDto
    {
        public int Id { get; set; }
        public DateTime DateOfTheEvent { get; set; }
        public int MasterId { get; set; }
        public string IdentityBuyerId { get; set; }

        public IdentityBuyer IdentityBuyer { get; set; }
        public MasterDto Master { get; set; }

        
    }
}
