using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest2ebt.UI.Models
{
    public class RentViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime DateOfBeginingRent { get; set; }

        [Required]
        public DateTime DateOfEndingRent { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        public double? Distance { get; set; }

        [Required]
        public double? Discount { get; set; }

        [Required]
        public bool IsNeedDelivery { get; set; }

        [Required]
        public bool IsBack { get; set; }
    }
}
