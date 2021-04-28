using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Data;
using Todo.Dtos;
using Todo.Queries;

namespace Todo.Handlers
{
    public class GetTodoByIdHandler : IRequestHandler<GetTodoByIdQuery, TodoDto>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public GetTodoByIdHandler(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TodoDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var todoItem = _context.TodoItems.Where(a => a.Id == request.Id).FirstOrDefault();
            if (todoItem == null) 
            {
                return null;
            }
            else
            {
                var todoDto = _mapper.Map<TodoDto>(todoItem);
                return todoDto;
            }
        }
    }
}
