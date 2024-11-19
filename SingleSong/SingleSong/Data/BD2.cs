using System.ComponentModel.DataAnnotations;

namespace SingleSong.Data
{
    public class BD2
    {
        public int ID { get; set; }
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{2,30}$", ErrorMessage = "Ощибка! Проверьте данные в поле \"Имя\".\n Поле не должно содержать спецсимволов.\n Длина поля от 3-30.")]
        public string Name { get; set; }
        public string Nationality { get; set; }
        public int Year { get; set; }
        public string Gender { get; set; }
        public string? Img { get; set; }
    }
}