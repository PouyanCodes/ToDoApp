
using TodoApp.Domain.Entities;
using TodoApp.Application.Contracts.Persistence;

namespace TodoApp.Persistence.Repositories
{
    public class TodoRepository :
        GenericRepository<Todo>, ITodoRepository
    {
        private readonly DataBaseContext _context;

        public TodoRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }
    }
}
