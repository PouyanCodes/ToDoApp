
using AutoMapper;
using TodoApp.MVC.Services.Base;
using TodoApp.MVC.Models.TodoVMs;

namespace TodoApp.MVC.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Todo, CreateTodoVM>().ReverseMap();

            CreateMap<EditTodoVM, Todo>();
            CreateMap<Todo, EditTodoVM>()
                .ForMember(t => t.DeadLine, m => m.MapFrom(t => t.Deadline.DateTime));

            CreateMap<Todo, TodoVM>()
                .ForMember(t => t.DeadLine, m => m.MapFrom(t => t.Deadline.Date))
                .ForMember(t => t.DeadLine, m => m.MapFrom(t => t.CreateDate.Date)); 
        }
    }
}
