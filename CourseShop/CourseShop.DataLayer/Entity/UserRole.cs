using System.ComponentModel.DataAnnotations;

namespace CourseShop.DataLayer.Entity
{
    public class UserRole
    {
        [Key]
        public int USR_RoleId { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }


        #region Relations

        public User User { get; set; }

        public Role Role { get; set; }

        #endregion
    }
}
