using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoIdentity.Models;

namespace ToDoIdentity.Data
{
    public class ToDoContext : IdentityDbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options)
                : base(options) { }
    }
}
