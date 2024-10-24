
using AutoMapper;
using TodoApp.MVC.Contracts;
using TodoApp.MVC.Services.Base;
using TodoApp.MVC.Models.TodoVMs;

namespace TodoApp.MVC.Services
{
    public class TodoService : BaseHttpService, ITodoService
    {
        private readonly IMapper _mapper;
        private readonly IClient httpClient;

        public TodoService(IMapper mapper, IClient httpClient) : base(httpClient)
        {
            _mapper = mapper;
            this.httpClient = httpClient;
        }

        public EditTodoVM GetById(int id)
        {
            var todo = httpClient.TodoGET(id);
            return _mapper.Map<EditTodoVM>(todo);
        }

        public List<TodoVM> GetAll()
        {
            return _mapper.Map<List<TodoVM>>(httpClient.TodoAll());
        }

        public int CreateTodo(CreateTodoVM createVM)
        {
            var todo = _mapper.Map<Todo>(createVM);
            httpClient.TodoPOST(todo);
            return todo.Id;
        }

        public void EditTodo(EditTodoVM editVM)
        {
            var todo = _mapper.Map<Todo>(editVM);
            httpClient.TodoPUT(todo.Id, todo);
        }

        public void DeleteTodo(int id)
        {
            httpClient.TodoDELETE(id);
        }

        public void CheckedTodo(int id)
        {
            var todo = httpClient.TodoGET(id);
            todo.Status = 1;
            httpClient.TodoPUT(todo.Id, todo);
        }

    }
}
