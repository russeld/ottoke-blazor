using OttokeBlazor.Server.Entities;
using OttokeBlazor.Shared;

namespace OttokeBlazor.Server.Extensions
{
    public static class TodoDtoConversions
    {
        public static IEnumerable<TodoDto> ConvertToDto(this IEnumerable<Todo> todos)
        {
            return (from todo in todos
                    select new TodoDto
                    {
                        Id = todo.Id,
                        Title = todo.Title,
                        IsDone = todo.IsDone,
                        CreatedAt = todo.CreatedAt
                    }).ToList();
        }

        public static TodoDto ConvertDto(this Todo todo)
        {
            return new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                IsDone = todo.IsDone,
                CreatedAt = todo.CreatedAt
            };
        }
    }
}
