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
using Todo.Models;

namespace Todo.Commands
{
    public class CreateNewTodoCommand : IRequest<TodoDto>
    {
        public TodoDto Todo { get; set; }
    }
}
