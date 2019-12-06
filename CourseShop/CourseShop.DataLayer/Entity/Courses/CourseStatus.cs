using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseShop.DataLayer.Entity.Courses
{
    public class CourseStatus
    {
        [Key]
        public int CourseStatusId { get; set; }

        [Display(Name = "وضعیت دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CourseStatusTitle { get; set; }

        #region relations

        public List<Course> Course { get; set; }

        #endregion
    }
}
