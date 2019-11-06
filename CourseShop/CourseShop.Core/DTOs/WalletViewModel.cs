using System;
using System.ComponentModel.DataAnnotations;

namespace CourseShop.Core.DTOs
{
    public class WalletViewModel
    {
        public int WalletId { get; set; }

        [Display(Name = "نوع تراکنش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TypeId { get; set; }


        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }

        [Display(Name = "شرح")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Description { get; set; }

        [Display(Name = "تاریخ و ساعت")]
        public DateTime CreateDate { get; set; }

    }

    public class CaharegeWalletViewModel
    {
        [Display(Name = "مقدار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }

        public int UserId { get; set; }

        public bool IsPay { get; set; } = false;

        public string Description { get; set; }

    }
}
