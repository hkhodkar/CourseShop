using System.ComponentModel.DataAnnotations;

namespace CourseShop.DataLayer.Entity.Courses
{
    public class CourseLevel
    {
        [Key]
        public int CourseLevelId { get; set; }


        [Display(Name = "سطح دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CourseLevelTitle { get; set; }
    }
}
