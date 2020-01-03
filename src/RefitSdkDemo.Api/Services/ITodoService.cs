using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RefitSdkDemo.Api.Domain;

namespace RefitSdkDemo.Api.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetTodosAsync();
        Task<Todo> GetTodoByIdAsync(Guid todoId);
        Task<bool> CreateTodoAsync(Todo todo);
        Task<bool> UpdateTodoAsync(Todo todo);
        Task<bool> DeleteTodoAsync(Guid todoId);
    }
}
