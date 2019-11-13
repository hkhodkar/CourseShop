using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseShop.DataLayer.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Username { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Email { get; set; }

        public bool IsActive { get; set; }


        public string PasswordHash { get; set; }

        public DateTime RegisterDate { get; set; }

        public string ActivateCode { get; set; }

        public string UserAvatar { get; set; }

        #region Relations

        public List<UserRole> UserRoles { get; set; }
        public virtual List<Wallet> Wallets { get; set; }

        #endregion
    }
}
