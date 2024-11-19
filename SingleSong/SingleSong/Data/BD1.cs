using System.ComponentModel.DataAnnotations;

namespace SingleSong.Data
{
    public class BD1
    {
        public int ID { get; set; }
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{2,30}$", ErrorMessage = "Ощибка! Проверьте данные в поле \"Название\".\n Поле не должно содержать спецсимволов.\n Длина поля от 3-30.")]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{2,30}$",ErrorMessage = "Ощибка! Проверьте данные в поле \"Исполнитель\".\n Поле не должно содержать спецсимволов.\n Длина поля от 3-30.")]
        public string IDSinger { get; set; }
        public string Language { get; set; }
        public int Year { get; set; }
        public string Genre {  get; set; }
        public int Quantity { get; set; }
        public string? Mp3 { get; set; }
        public string? Img { get; set; }
    }
}