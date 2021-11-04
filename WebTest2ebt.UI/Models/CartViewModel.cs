using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.UI.Models
{
    public class CartViewModel
    {
        [Required]
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public IEnumerable<Equipment> Equipments { get; set; }
        public string ReturnUrl { get; set; }
        //[Required]
        //public int IdentityBuyerId { get; set; }


        //[Required]
        //public List<Rent> Rents { get; set; }
    }
}
