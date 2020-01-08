using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RefistSdkDemo.PlainClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            const string todoApi = "https://localhost:44311";

            var createTodoRequest = new CreateTodoRequest
            {
                Name = "Plain Client Todo Item", 
                IsCompleted = false
            };

            using var client = new HttpClient {BaseAddress = new Uri(todoApi)};
            using var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/todos");

            var json = JsonSerializer.Serialize(createTodoRequest);

            using var stringContent = 
                new StringContent(json, Encoding.UTF8, "application/json");
            request.Content = stringContent;

            using var todoResponse = await client.SendAsync(request);
            
            var responseBody = await todoResponse.Content.ReadAsStringAsync();
            var todoItem = JsonSerializer.Deserialize<CreateTodoResponse>(responseBody,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});

            Console.WriteLine($"New Todo Item Id: {todoItem.Id}");
            Console.ReadKey();
        }
    }

    public class CreateTodoRequest
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set;}
    }

    public class CreateTodoResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set;}
    }
}
