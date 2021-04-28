using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Commands;
using Todo.Data;
using Todo.Dtos;
using Todo.Models;
using Todo.Queries;

namespace Todo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async virtual Task<List<TodoDto>> GetAll()
        {
            return await _mediator.Send(new GetAllTodoQuery());
        }

        [HttpGet("{id}")]
        public async Task<TodoDto> GetById(int id)
        {
            return await _mediator.Send(new GetTodoByIdQuery() { Id = id });
        }

        [HttpPost]
        public async Task Create(TodoDto dto)
        {
            await _mediator.Send(new CreateNewTodoCommand() { Todo = dto});
        }

        [HttpPut("{id}")]
        public async Task Update(int id,TodoDto dto)
        {
            await _mediator.Send(new UpdateTodoCommand() { Todo = dto, Id = id });
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleateById(int id)
        {
           return await _mediator.Send(new DeleteTodoByIdCommand() { Id = id });
        }
    }
}
