using AutoMapper;
using Todo.Dtos;
using Todo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoDto, TodoItem>().ReverseMap();
        }
    }
}
