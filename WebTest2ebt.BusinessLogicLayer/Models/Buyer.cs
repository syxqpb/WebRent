using System.Collections.Generic;


namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class Buyer
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PassportNumber { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<OrderMaster> OrderMasters { get; set; }
    }
}
