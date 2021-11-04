using System;

namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public DateTime TimeOfComment { get; set; }
        public string FeedBackMessage { get; set; }
        public string Topic { get; set; }
        public int MasterId { get; set; }
        public int BuyerId { get; set; }

        public Master Master { get; set; }
        public Buyer Buyer { get; set; }
    }
}
