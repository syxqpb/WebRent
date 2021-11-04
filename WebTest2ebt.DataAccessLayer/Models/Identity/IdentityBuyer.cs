using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTest2ebt.DataAccessLayer.Models.Identity
{
    public class IdentityBuyer : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PassportNumber { get; set; }

        public List<CartDto> Carts { get; set; }

        public List<FeedbackDto> Feedbacks { get; set; }
        public List<OrderMasterDto> OrderMasters { get; set; }

    }
}
