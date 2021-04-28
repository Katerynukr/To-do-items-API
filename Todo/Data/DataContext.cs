using Microsoft.EntityFrameworkCore;
using Todo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Data
{
    public class DataContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
