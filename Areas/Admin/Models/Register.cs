using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YinHua.Areas.Admin.Models
{
    public class Register 
    {
        [DisplayName("手机号码")]
        [Required]
        [StringLength(11)]
        [RegularExpression(@"(^(13\d|15[^4,\D]|17[13678]|18\d)\d{8}|170[^346,\D]\d{7})$", ErrorMessage = "请输入正确的手机号码")]
        public string MobileNumber { get; set; }

        [DisplayName("姓名")]
        [Required]
        public string Name { get; set; }

        [DisplayNameAttribute("性别")]
        [Required]
        [StringLengthAttribute(10)]
        public string Sex { get; set; }


        [DisplayNameAttribute("邮箱地址")]
        [EmailAddressAttribute]
        [StringLengthAttribute(50)]
        public string Email { get; set; }

        [DisplayNameAttribute("区域")]
        [StringLengthAttribute(400)]
        public string Area { get; set; }

        [DisplayNameAttribute("学校/公司")]
        [StringLengthAttribute(50)]
        public string Company { get; set; }

        [RequiredAttribute]
        [StringLengthAttribute(100)]
        [DataTypeAttribute(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [DataTypeAttribute(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}