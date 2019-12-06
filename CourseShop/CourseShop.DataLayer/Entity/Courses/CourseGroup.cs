using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseShop.DataLayer.Entity.Courses
{
    public class CourseGroup
    {

        [Key]
        public int CourseGroupId { get; set; }

        [Display(Name = "نام گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CourseGroupTitle { get; set; }

        [Display(Name = "حذف شده؟")]
        public bool IsDeleted { get; set; }

        [Display(Name = "گروه اصلی؟")]
        public int? ParentId { get; set; }

        #region Relations

        [ForeignKey("ParentId")]
        public List<CourseGroup> CourseGroups { get; set; }

        [InverseProperty("CourseGroup")]
        public List<Course> Courses { get; set; }

        [InverseProperty("SubGroup")]
        public List<Course> SubCourses { get; set; }
        #endregion

    }
}
