using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace webApi_aspnet.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}