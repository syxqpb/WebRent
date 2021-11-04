using System.ComponentModel.DataAnnotations.Schema;


namespace WebTest2ebt.DataAccessLayer.Models
{

    public class LensDto : EquipmentDto
    {
        public string TypeOfLens { get; set; } 
        public ushort FocalLength { get; set; }
        public double Diaphragm { get; set; } 
        public int FilterDiameter { get; set; }
        public string LensMount { get; set; } 
        public bool IsAutoFocus { get; set; }
        public int Weight { get; set; } 
    }
}
