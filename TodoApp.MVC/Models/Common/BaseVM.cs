
using System.ComponentModel.DataAnnotations;

namespace TodoApp.MVC.Models.Common
{
    public class BaseVM
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }


        [Display(Name = "توضیحات")]
        public string? Description { get; set; }


        [Display(Name = "وضعیت")]
        public int Status { get; set; }

    }
}
