using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace WebTest2ebt.DataAccessLayer.Models
{
    public class BatteryDto : EquipmentDto
    {
        
        public string TypeOfBattery { get; set; } 
        public string Capacity { get; set; } 
        public string SupplyVoltage { get; set; } 

    }
}
