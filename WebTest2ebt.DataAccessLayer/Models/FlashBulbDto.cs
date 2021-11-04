using System.ComponentModel.DataAnnotations.Schema;

namespace WebTest2ebt.DataAccessLayer.Models
{
    public class FlashBulbDto : EquipmentDto
    {
        public string LeadingNumber { get; set; } 
        public string LightSource { get; set; } 
        public bool AvailabilityOfLCDScreen { get; set; }
        public bool HeadRotation { get; set; } 
        public string PowerSupply { get; set; } 
    }
}
