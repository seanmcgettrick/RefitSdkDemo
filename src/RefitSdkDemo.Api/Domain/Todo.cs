using System;
using System.ComponentModel.DataAnnotations;
namespace RefitSdkDemo.Api.Domain
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
