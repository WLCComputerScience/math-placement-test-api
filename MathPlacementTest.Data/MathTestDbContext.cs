using System;
using Microsoft.EntityFrameworkCore;

namespace MathPlacementTest.Data
{
    public class MathTestDbContext : DbContext
    {
        public DbSet<StudentData> studentData { get; set; }
        public DbSet<CourseTaken> CoursesTaken { get; set; }
        public DbSet<PastCourse> PastCourses { get; set; }
        //public DbSet<Question> Questions { get; set; }
        //public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<Student> Students { get; set; }
        //public DbSet<TestQuestion> TestQuestions { get; set; }
        //public DbSet<Test> Tests { get; set; }
        //public dbset<coursetaken> coursestaken { get; set; }
        //public dbset<question> questions { get; set; }
        //public dbset<studentanswer> studentanswers { get; set; }
        //public dbset<testquestion> testquestions { get; set; }
        //public dbset<test> tests { get; set; }

        public MathTestDbContext(DbContextOptions<MathTestDbContext> options) : base(options)
        {
            
        }
    }
}
