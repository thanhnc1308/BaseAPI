using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class TodoContext : BaseContext
    {
        public TodoContext(string connection) : base(connection)
        {

        }

        public DbSet<Todo> Todo { get; set; }
    }
}
