
namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class Microphone : Equipment
    {
        public string Supply { get; set; } //Питание электричества
        public string FrequencyRange { get; set; } //Частотный диапозон
        public string Focus { get; set; } //Направленность
        public string Connector { get; set; } //Разъем
        public ushort Weight { get; set; } //Вес микрофона
    }
}
