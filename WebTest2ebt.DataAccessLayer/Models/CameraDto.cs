using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebTest2ebt.DataAccessLayer.Models
{

    public class CameraDto : EquipmentDto
    {
        public string TypeOfCamera { get; set; } 
        public string TypeOfMatrix { get; set; } 
        public string CountOfMatrixPoint { get; set; } 
        public string MaxFrameSize { get; set; } 
        public string MaxFrameRate { get; set; } 
        public string BatteryType { get; set; } 
        public ushort Weight { get; set; } 
    }
}
