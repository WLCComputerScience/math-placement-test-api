using System;
using Microsoft.EntityFrameworkCore;

namespace MathPlacementTest.Data
{
    public class MathTestDbContext : DbContext
    {
        public DbSet<StudentData> studentData { get; set; }

        public MathTestDbContext(DbContextOptions<MathTestDbContext> options) : base(options)
        {

        }
    }
}
