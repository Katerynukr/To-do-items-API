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
    public class CreateNewTodoHandler : IRequestHandler<CreateNewTodoCommand, TodoDto>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CreateNewTodoHandler(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<TodoDto> Handle(CreateNewTodoCommand command, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<TodoItem>(command.Todo);
            _context.Add(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<TodoDto>(item);
        }
    }
}
