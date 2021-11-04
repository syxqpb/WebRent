using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest2ebt.UI.Models
{
    public class CameraViewModel : EquipmentViewModel
    {
        [Required]
        public string TypeOfCamera { get; set; }

        [Required]
        public string TypeOfMatrix { get; set; }

        [Required]
        public string CountOfMatrixPoint { get; set; }

        [Required]
        public string MaxFrameSize { get; set; }

        [Required]
        public string MaxFrameRate { get; set; }

        [Required]
        public string BatteryType { get; set; }

        [Required]
        public ushort Weight { get; set; } 
    }
}
