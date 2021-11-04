using System.ComponentModel.DataAnnotations.Schema;

namespace WebTest2ebt.DataAccessLayer.Models
{
    public class MicrophoneDto : EquipmentDto
    {
        public string Supply { get; set; } 
        public string FrequencyRange { get; set; }
        public string Focus { get; set; } 
        public string Connector { get; set; } 
        public ushort Weight { get; set; }
    }
}
