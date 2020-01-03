using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RefitSdkDemo.Api.Data;
using RefitSdkDemo.Api.Domain;

namespace RefitSdkDemo.Api.Services
{
    public class TodoService : ITodoService
    {
        private readonly DataContext _dataContext;

        public TodoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Todo>> GetTodosAsync()
        {
            return await _dataContext.Todos.ToListAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(Guid todoId)
        {
            return await _dataContext.Todos.SingleOrDefaultAsync(t => t.Id == todoId);
        }

        public async Task<bool> CreateTodoAsync(Todo todo)
        {
            await _dataContext.Todos.AddAsync(todo);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateTodoAsync(Todo todo)
        {
            _dataContext.Todos.Update(todo);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;


        }

        public async Task<bool> DeleteTodoAsync(Guid todoId)
        {
            var todo = await GetTodoByIdAsync(todoId);
            _dataContext.Todos.Remove(todo);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
