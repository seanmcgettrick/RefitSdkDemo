using System;
using System.Collections.Generic;
using System.Text;

namespace RefistSdkDemo.ApiContracts.V1.Requests
{
    public class UpdateTodoRequest
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
