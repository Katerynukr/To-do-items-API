using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Commands
{
    public class DeleteTodoByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
