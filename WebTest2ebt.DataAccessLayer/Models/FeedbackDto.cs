using System;
using System.Collections.Generic;
using System.Text;
using WebTest2ebt.DataAccessLayer.Models.Identity;

namespace WebTest2ebt.DataAccessLayer.Models
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public DateTime TimeOfComment { get; set; }
        public string FeedBackMessage { get; set; }
        public string Topic { get; set; }
        public int? MasterId { get; set; }
        public int? IdentityBuyerId { get; set; }
        
        public MasterDto Master { get; set; }
        public IdentityBuyer IdentityBuyer { get; set; }
    }
}
