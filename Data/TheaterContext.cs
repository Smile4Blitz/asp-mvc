using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class TheaterContext : DbContext
    {
        public TheaterContext (DbContextOptions<TheaterContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.NewsMessage> NewsMessage { get; set; } = default!;
    }
}
