using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseShop.DataLayer.Entity
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Display(Name = "نام نفش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string RoleTitle { get; set; }

        public bool IsDeleted { get; set; }

        #region UserRole

        public List<UserRole> UserRoles { get; set; }

        public List<RolePermission> RolePermissions { get; set; }

        #endregion

    }
}
