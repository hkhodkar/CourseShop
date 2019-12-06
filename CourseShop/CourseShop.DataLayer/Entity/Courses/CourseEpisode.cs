using System;
using System.ComponentModel.DataAnnotations;

namespace CourseShop.DataLayer.Entity.Courses
{
    public class CourseEpisode
    {
        [Key]
        public int EpisodeId { get; set; }

        public int CourseId { get; set; }

        [Display(Name = "عنوان بخش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string EpisodeTitle { get; set; }

        [Display(Name = "زمان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public TimeSpan EpisodeTiem { get; set; }

        [Display(Name = "فایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EpisodeFileName { get; set; }

        [Display(Name = "رایگان")]
        public bool IsFree { get; set; }

        #region relation
        public Course Course { get; set; }
        #endregion
    }
}
