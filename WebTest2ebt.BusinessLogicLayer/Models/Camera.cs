
namespace WebTest2ebt.BusinessLogicLayer.Models
{
    public class Camera : Equipment
    {
        public string TypeOfCamera { get; set; } //Тип камеры(зеркальная, беззеркальная)
        public string TypeOfMatrix { get; set; } //Тип матрицы
        public string CountOfMatrixPoint { get; set; } //Количество пикселей матрицы
        public string MaxFrameSize { get; set; } //Максимальное разрешение снимка
        public string MaxFrameRate { get; set; } //Максимальное количество кадров в секунду
        public string BatteryType { get; set; } //
        public ushort Weight { get; set; } //Вес камеры
    }
}
