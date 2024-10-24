
using TodoApp.MVC.Models.TodoVMs;

namespace TodoApp.MVC.Contracts
{
    public interface ITodoService
    {
        EditTodoVM GetById(int id);
        List<TodoVM> GetAll();
        int CreateTodo(CreateTodoVM createVM);
        void EditTodo(EditTodoVM editVM);
        void DeleteTodo(int id);
        void CheckedTodo(int id);
    }
}
