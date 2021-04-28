using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Commands;
using Todo.Data;

namespace Todo.Handlers
{
    public class DeleteTodoByIdHandler : IRequestHandler<DeleteTodoByIdCommand, int>
    {
        private readonly DataContext _context;

        public DeleteTodoByIdHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteTodoByIdCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _context.TodoItems.Where(t => t.Id == request.Id).FirstOrDefaultAsync();
            if (todoItem == null) return default;
            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            return todoItem.Id;
        }
    }
}
