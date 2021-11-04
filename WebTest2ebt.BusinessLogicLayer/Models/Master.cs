
using System.Collections.Generic;

namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class Master
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Price { get; set; }
        public string Description { get; set; } //
        public int ServiceId { get; set; }
        public bool IsBusyNow { get; set; }
        public List<PhotoAndVideo> PhotosAndVideos { get; set; }//
        public List<Feedback> FeedBack { get; set; }//
        public List<OrderMaster> OrderMasters { get; set; }
        public Service Service { get; set; }
    }
}
