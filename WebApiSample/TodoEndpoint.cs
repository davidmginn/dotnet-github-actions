using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApiSample;

public static class TodoEndpoint
{
    public static RouteGroupBuilder MapTodoApi(this RouteGroupBuilder routeGroupBuilder)
    {
        routeGroupBuilder.MapGet("/", GetAllTodos);
        //routeGroupBuilder.MapGet("/{id:int}", GetTodoById);

        return routeGroupBuilder;
    }

        public static async Task<Ok<List<Todo>>> GetAllTodos()
        {
            var todos = new List<Todo>()
            {
                new Todo { Id = 1, Title = "Do this", Description = "Do this thing", IsDone = false },
                new Todo { Id = 2, Title = "Do that", Description = "Do that thing", IsDone = false },
                new Todo { Id = 3, Title = "Do the other", Description = "Do the other thing", IsDone = false },
            };
            
            return await Task.FromResult(TypedResults.Ok<List<Todo>>(todos));
        }

        // public static async Task<IResult> GetTodoById(int id)

        // {
        //     var todos = new List<Todo>()
        //     {
        //         new Todo { Id = 1, Title = "Do this", Description = "Do this thing", IsDone = false },
        //         new Todo { Id = 2, Title = "Do that", Description = "Do that thing", IsDone = false },
        //         new Todo { Id = 3, Title = "Do the other", Description = "Do the other thing", IsDone = false },
        //     };

        //     var todo = todos.FirstOrDefault(t => t.Id == id);

        //     if (todo is null)
        //     {
        //         return await Task.FromResult(TypedResults.NotFound());
        //     }

        //     return await Task.FromResult(TypedResults.Ok(todo));
        // }
}
