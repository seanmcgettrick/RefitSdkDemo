using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RefistSdkDemo.ApiContracts;
using RefistSdkDemo.ApiContracts.V1.Requests;
using RefistSdkDemo.ApiContracts.V1.Responses;
using RefitSdkDemo.Api.Domain;
using RefitSdkDemo.Api.Services;

namespace RefitSdkDemo.Api.Controllers.V1
{
    public class TodosController : Controller
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodosController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Todos.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoService.GetTodosAsync();

            return Ok(_mapper.Map<List<TodoResponse>>(todos));
        }

        [HttpGet(ApiRoutes.Todos.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid todoId)
        {
            var todo = await _todoService.GetTodoByIdAsync(todoId);

            if (todo == null)
                return NotFound(todoId);

            return Ok(_mapper.Map<TodoResponse>(todo));
        }

        [HttpPost(ApiRoutes.Todos.Create)]
        public async Task<IActionResult> Create([FromBody] CreateTodoRequest todoRequest)
        {
            if (string.IsNullOrEmpty(todoRequest.Name))
                return BadRequest();

            var newTodoId = Guid.NewGuid();

            var todo = new Todo
            {
                Id = newTodoId,
                Name = todoRequest.Name,
                IsCompleted = todoRequest.IsCompleted
            };

            await _todoService.CreateTodoAsync(todo);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl +
                              "/" + ApiRoutes.Todos.Get.Replace("{todoId}", newTodoId.ToString());

            return Created(locationUri, _mapper.Map<TodoResponse>(todo));
        }

        [HttpPut(ApiRoutes.Todos.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid todoId, [FromBody]UpdateTodoRequest request)
        {
            var todo = await _todoService.GetTodoByIdAsync(todoId);
            if (todo == null)
                return NotFound(todoId);

            todo.Name = request.Name;
            todo.IsCompleted = request.IsCompleted;

            var updated = await _todoService.UpdateTodoAsync(todo);

            if (updated)
                return Ok(_mapper.Map<TodoResponse>(todo));

            return NotFound(todoId);
        }

        [HttpDelete(ApiRoutes.Todos.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid todoId)
        {
            var deleted = await _todoService.DeleteTodoAsync(todoId);

            if (deleted)
                return NoContent();

            return NotFound(todoId);
        }
    }
}