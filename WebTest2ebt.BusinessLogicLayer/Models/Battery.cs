
namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class Battery : Equipment
    {
        public string TypeOfBattery { get; set; } //Тип аккамуляторов(Li-ion,Li-pol)
        public string Capacity { get; set; } //Емкость
        public string SupplyVoltage { get; set; } //Напряжение питания
        public int Weight { get; set; } //Вес объектива
    }
}
