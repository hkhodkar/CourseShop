using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseShop.DataLayer.Entity.Courses
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Display(Name = " گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public int GroupId { get; set; }

        public int? SubGroupId { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Display(Name = "وضعیت دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CourseStatusId { get; set; }


        [Display(Name = "سطح دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CourseLevelId { get; set; }

        [Display(Name = "نام دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CourseTitle { get; set; }


        [Display(Name = "شرح دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseDescription { get; set; }


        [Display(Name = "قیمت دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public int CoursePrice { get; set; }



        #region relations

        [ForeignKey("TeacherId")]
        public User User { get; set; }

        [ForeignKey("GroupId")]
        public CourseGroup CourseGroup { get; set; }


        [ForeignKey("SubGroupId")]
        public CourseGroup SubGroup { get; set; }

        [ForeignKey("CourseStatusId")]
        public CourseStatus CourseStatus { get; set; }

        [ForeignKey("CourseLevelId")]
        public CourseLevel CourseLevel { get; set; }

        [MaxLength(600)]
        public string Tags { get; set; }

        [MaxLength(50)]
        public string ImageName { get; set; }

        [MaxLength(50)]
        public string DemoFileName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public List<CourseEpisode> CourseEpisodes { get; set; }

        #endregion

    }
}
