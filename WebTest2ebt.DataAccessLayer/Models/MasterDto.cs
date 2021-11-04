using System;
using System.Collections.Generic;
using System.Text;


namespace WebTest2ebt.DataAccessLayer.Models
{
    public class MasterDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int ServiceId { get; set; }
        public bool IsBusyNow { get; set; }
        public List<PhotoAndVideoDto> PhotosAndVideos { get; set; }
        public List<FeedbackDto> FeedBack { get; set; }

        public List<OrderMasterDto> OrderMasters { get; set; }
        public ServiceDto Service { get; set; }
    }
}
