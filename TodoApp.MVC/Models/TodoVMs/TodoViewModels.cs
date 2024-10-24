
using TodoApp.MVC.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.MVC.Models.TodoVMs
{
    public class TodoVM : BaseVM
    {
        public int Id { get; set; }
        public string DeadLine { get; set; }
        public string CreateDate { get; set; }
    }

    public class CreateTodoVM : BaseVM
    {
        [Display(Name = "زمان سررسید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime DeadLine { get; set; }
    }

    public class EditTodoVM : BaseVM 
    {
        public int Id { get; set; }

        [Display(Name = "زمان سررسید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime DeadLine { get; set; }
    }

}
