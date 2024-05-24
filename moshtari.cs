using System.ComponentModel.DataAnnotations;

namespace kiramtush.Models
{
    public class moshtari
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "اسم الزامیست")]
        public string Name { get; set; }
        [Required(ErrorMessage = "یوزر نیم الزامیست")]
        [MinLength(8, ErrorMessage = "یوزر نیم باید 8 کارکتر باشد")]
        public string Username { get; set; }
        [Required(ErrorMessage = "اسم الزامیست")]
        [MinLength(8, ErrorMessage = "پسوورد باید 8 کارکتر باشد")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "پسوورد مطابقط ندارد")]
        [Required(ErrorMessage = "تایید پسوورد الزامیست")]
        public string ConfirmPassword { get; set; }
        [RegularExpression(@"09\d{9}",ErrorMessage ="شماره موبایل نیاز است")]
        [Required(ErrorMessage ="شماره موبایل الزامیست")]
        public string PhoneNumber { get; set; }
    }
}
