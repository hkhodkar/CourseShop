using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseShop.DataLayer.Entity
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [Display(Name = "نام دسترسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string PermissionTitle { get; set; }

        [Required]
        [MaxLength(150)]
        public string PermissionNameForAttribute { get; set; }

        public int? ParrentId { get; set; }


        #region Relations

        [ForeignKey("ParrentId")]
        public List<Permission> Permissions { get; set; }

        public List<RolePermission> RolePermissions { get; set; }

        #endregion
    }
}
