using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesAudios.Models;

namespace RazorPagesAudios.Data
{
    public class RazorPagesAudiosContext : DbContext
    {
        public RazorPagesAudiosContext (DbContextOptions<RazorPagesAudiosContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesAudios.Models.Audio> Audio { get; set; } = default!;
    }
}
