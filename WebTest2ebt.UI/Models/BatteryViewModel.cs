using System.ComponentModel.DataAnnotations;


namespace WebTest2ebt.UI.Models
{
    public class BatteryViewModel : EquipmentViewModel
    {
        [Required]
        public string Manufacture { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string TypeOfBattery { get; set; }

        [Required]
        public string Capacity { get; set; }

        [Required]        
        public string SupplyVoltage { get; set; }

    }
}
