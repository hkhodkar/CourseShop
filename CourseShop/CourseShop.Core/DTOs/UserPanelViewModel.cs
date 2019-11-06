using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace CourseShop.Core.DTOs
{
    public class UserPanelViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Username { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public string AvatarName { get; set; }
    }


    public class EditProfileViewModel
    {

        public string AvatarName { get; set; }

        public IFormFile UserAvatar { get; set; }

    }

    public class ChangePasswordViewModel
    {
        [Display(Name = " رمز عبورفعلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string OldPassword { get; set; }


        [Display(Name = "رمز عبورجدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string NewPassword { get; set; }


        [Display(Name = " تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [Compare("NewPassword", ErrorMessage = "رمز عبور با تکرار آن مغایرت دارد")]
        public string Repassword { get; set; }

    }


}
