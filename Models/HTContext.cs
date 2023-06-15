using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RazorPageDemo.Models
{
    public class HTContext : DbContext
    {
        public HTContext(DbContextOptions<HTContext> o) : base(o)
        {
        }
        public DbSet<FAQ> FAQ { get; set; } = default!;

    }
}
