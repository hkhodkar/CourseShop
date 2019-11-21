using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseShop.Core.DTOs
{
    public class UserForAdminViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Username { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Email { get; set; }


        public string Password { get; set; }

        public string Repassword { get; set; }

        public DateTime RegisterDate { get; set; }

        [Display(Name = "عکس پروفایل")]
        public string AvatarName { get; set; }

        public IFormFile UserAvatar { get; set; }

        public List<int> Roles { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActivate { get; set; }
    }
}
