using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RefistSdkDemo.ApiContracts.V1.Requests;
using RefistSdkDemo.ApiContracts.V1.Responses;
using Refit;

namespace RefistSdkDemo.ApiSdk
{
    public interface ITodoApi
    {
        [Get("/api/v1/todos")]
        Task<ApiResponse<List<TodoResponse>>> GetAllAsync();

        [Get("/api/v1/todos/{todoId}")]
        Task<ApiResponse<TodoResponse>> GetAsync(Guid todoId);

        [Post("/api/v1/todos")]
        Task<ApiResponse<TodoResponse>> CreateAsync([Body] CreateTodoRequest createTodoRequest);
        
        [Put("/api/v1/todos/{todoId}")]
        Task<ApiResponse<TodoResponse>> UpdateAsync(Guid todoId, [Body] UpdateTodoRequest updatePostRequest);
        
        [Delete("/api/v1/todos/{todoId}")]
        Task<ApiResponse<string>> DeleteAsync(Guid todoId);
    }
}
