using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Dtos;

namespace Todo.Queries
{
    public class GetTodoByIdQuery : IRequest<TodoDto>
    {
        public int Id { get; set; }
    }
}
