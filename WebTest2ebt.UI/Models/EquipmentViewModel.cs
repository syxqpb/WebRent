using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.BusinessLogicLayer.Models;

namespace WebTest2ebt.UI.Models
{
    public class EquipmentViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Производитель")]
        public string Manufacturer { get; set; }

        [Required]
        [Display(Name = "Модель")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Тип техники")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Дата поступления")]
        public DateTime? ReceiptDate { get; set; }

        [Required]
        [Display(Name = "Дата списания")]
        public DateTime? WriteOffDate { get; set; }

        [Required]
        [Display(Name = "Состояние")]
        public int Сondition { get; set; }
        [Required]
        [Display(Name = "Цена")]
        public double Сost { get; set; }
        [Required]
        public bool IsTaken { get; set; }
        [Required]
        public List<EquipmentPhoto> equipmentPhotos { get; set; }
        [Required]
        public List<Cart> Carts { get; set; }
    }
}
