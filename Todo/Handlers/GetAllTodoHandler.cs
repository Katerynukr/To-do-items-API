using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetAllTodoHandler : IRequestHandler<GetAllTodoQuery, List<TodoDto>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public GetAllTodoHandler(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<TodoDto>> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.TodoItems.ToListAsync();
            return _mapper.Map<List<TodoDto>>(entities);
        }
    }
}
