using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.UI.Models
{
    public class MasterViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public bool IsBusyNow { get; set; }
        [Required]
        public List<PhotoAndVideo> PhotosAndVideos { get; set; }
        [Required]
        public List<Feedback> FeedBack { get; set; }
        [Required]
        public List<OrderMaster> OrderMasters { get; set; }
        //[Required]
        //public Portfolio Portfolio { get; set; }
    }
}
