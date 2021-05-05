using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentDetailsDataFetcher : IStudentDetailsDataFetcher
    {
        private readonly MathTestDbContext _dbContext;

        public StudentDetailsDataFetcher(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student GetStudent(int studentId)
        {
            var student = _dbContext.Students.Where(p => p.StudentId == studentId).FirstOrDefault();
            return student;
        }


    }
}
