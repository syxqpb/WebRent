
namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class Lens : Equipment
    {
        public string TypeOfLens { get; set; } //Тип объектива
        public ushort FocalLength { get; set; } //фокусное расстояние(мм)
        public double Diaphragm { get; set; } //Светосила(диафрагма,2.0 или подобное)
        public int FilterDiameter { get; set; } //Диаметр резьбы для светофильтра
        public string LensMount { get; set; } //Крепление объектива(модель камеры)
        public bool IsAutoFocus { get; set; } //Наличие автоматической фокусировки
        public int Weight { get; set; } //Вес объектива
    }
}
