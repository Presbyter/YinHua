using System.ComponentModel.DataAnnotations;

namespace YinHua.Areas.Admin.Models
{
    public class LoginModel
    {
        [RequiredAttribute]
        [RegularExpression(@"(^(13\d|15[^4,\D]|17[13678]|18\d)\d{8}|170[^346,\D]\d{7})$", ErrorMessage = "请输入正确的手机号码")]
        public string MobileNumber { get; set; }
        [RequiredAttribute]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}