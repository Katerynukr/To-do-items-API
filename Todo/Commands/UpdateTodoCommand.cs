using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Dtos;

namespace Todo.Commands
{
    public class UpdateTodoCommand : IRequest<TodoDto>
    {
        public TodoDto Todo { get; set; }
        public int Id { get; set; }
    }
}
