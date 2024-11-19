using System.ComponentModel.DataAnnotations;

namespace SingleSong.Data
{
    [Serializable]
    public class BD3
    {
        public int ID { get; set; }
        public string? Img { get; set; }

        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{2,30}$", ErrorMessage = "Ощибка! Проверьте данные в поле Name.\n Поле не должно содержать спецсимволов.\n Длина поля от 3-30.")]
        public string Name { get; set; }
        [RegularExpression(@"^[-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$", ErrorMessage = "Ощибка! Проверьте данные в поле Email.\n Поле должно быть email.")]
        public string Mail { get; set; }
        [RegularExpression(@"^[-\w.]{7,30}$", ErrorMessage = "Ощибка! Проверьте данные в поле Password.\n Длина поля от 8-30.")]
        public string Password {get; set; }
    }
}