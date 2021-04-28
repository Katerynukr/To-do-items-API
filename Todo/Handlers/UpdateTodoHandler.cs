using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Commands;
using Todo.Data;
using Todo.Dtos;
using Todo.Models;

namespace Todo.Handlers
{
    public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, TodoDto>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UpdateTodoHandler(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TodoDto> Handle(UpdateTodoCommand command, CancellationToken cancellationToken)
        {
            var todoItem = _context.TodoItems.Where(i => i.Id == command.Id).FirstOrDefault();
            todoItem.Title = command.Todo.Title;
            _context.Update(todoItem);
            await _context.SaveChangesAsync();
            return _mapper.Map<TodoDto>(todoItem);
        }
    }
}
