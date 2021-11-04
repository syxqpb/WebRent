using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.UI.Models
{
    public class FeedbackViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime TimeOfComment { get; set; }
        [Required]
        public string FeedBackMessage { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public int? MasterId { get; set; }
        [Required]
        public int? IdentityBuyerId { get; set; }
        [Required]
        public Master Master { get; set; }
        [Required]
        public Buyer Buyer { get; set; }
    }
}
