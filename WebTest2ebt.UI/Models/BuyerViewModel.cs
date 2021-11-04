using System.ComponentModel.DataAnnotations;

namespace WebTest2ebt.UI.Models
{
    public class BuyerViewModel
    {
        //[Required]
        //public int Id { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PassportNumber { get; set; }
    }
}
