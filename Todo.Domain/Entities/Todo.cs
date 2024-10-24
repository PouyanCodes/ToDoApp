
using TodoApp.Domain.Common;

namespace TodoApp.Domain.Entities
{
    public class Todo : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        public DateTime Deadline { get;set; }
    }
}
