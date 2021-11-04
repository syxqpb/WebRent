
namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class FlashBulb : Equipment
    {
        public string LeadingNumber { get; set; } //Ведущее число(ISO, расстояние максимума света "58м")
        public string LightSource { get; set; } //Источник света(название ламп)
        public bool AvailabilityOfLCDScreen { get; set; } //Наличие ЖК-экрана
        public bool HeadRotation { get; set; } //Поворот головки
        public string PowerSupply { get; set; } //Источник питания
        public int Weight { get; set; } //Вес вспышки
    }
}
