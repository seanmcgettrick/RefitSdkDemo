using System;
using System.Threading.Tasks;
using RefistSdkDemo.ApiContracts.V1.Requests;
using RefistSdkDemo.ApiContracts.V1.Responses;
using RefistSdkDemo.ApiSdk;
using Refit;

namespace RefitSdkDemo.ApiSdkClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var todoApi = RestService.For<ITodoApi>("https://localhost:44311/");

            Console.WriteLine("Creating Todo Item...");
            var createTodoResponse = await todoApi.CreateAsync(new CreateTodoRequest
            {
                Name = "Todo Item Created from SDK",
                IsCompleted = false
            });

            TodoResponse todoResponse = createTodoResponse.Content;

            Console.WriteLine($"Name:{todoResponse.Name} ({todoResponse.Id})");
            Console.WriteLine($"Completed: {todoResponse.IsCompleted}");

            var todoItemId = todoResponse.Id;

            Console.WriteLine("\nUpdating Todo Item...");
            var updateTodoResponse = await todoApi.UpdateAsync(todoItemId, new UpdateTodoRequest
            {
                IsCompleted = true
            });

            todoResponse = updateTodoResponse.Content;

            Console.WriteLine($"Name:{todoResponse.Name} ({todoResponse.Id})");
            Console.WriteLine($"Completed: {todoResponse.IsCompleted}");

            Console.WriteLine("\nDeleting Todo Item...");
            var deleteTodoResponse = await todoApi.DeleteAsync(todoItemId);

            Console.WriteLine("\nGetting All Todo Items...");
            var getAllTodoResponse = await todoApi.GetAllAsync();

            var todoItems = getAllTodoResponse.Content;

            Console.WriteLine($"Todo Items Remaining: {todoItems.Count}");

            Console.ReadKey();
        }
    }
}
