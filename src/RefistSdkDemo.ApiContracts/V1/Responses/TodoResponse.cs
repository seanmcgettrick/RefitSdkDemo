using System;

namespace RefistSdkDemo.ApiContracts.V1.Responses
{
    public class TodoResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
