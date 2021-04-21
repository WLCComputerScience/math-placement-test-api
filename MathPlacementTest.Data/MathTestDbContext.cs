using System;
using Microsoft.EntityFrameworkCore;

namespace MathPlacementTest.Data
{
    public class MathTestDbContext : DbContext
    {
        public DbSet<StudentData> studentData { get; set; }
        //public dbset<coursetaken> coursestaken { get; set; }
        //public dbset<question> questions { get; set; }
        //public dbset<studentanswer> studentanswers { get; set; }
        public DbSet<Student> students { get; set; }
        //public dbset<testquestion> testquestions { get; set; }
        //public dbset<test> tests { get; set; }

        public MathTestDbContext(DbContextOptions<MathTestDbContext> options) : base(options)
        {
            
        }
    }
}
