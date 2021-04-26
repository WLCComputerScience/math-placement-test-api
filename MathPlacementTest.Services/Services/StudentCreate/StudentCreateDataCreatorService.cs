using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentCreateDataCreatorService : IStudentCreateDataCreatorService
    {
        private readonly MathTestDbContext _dbContext;
        
        public StudentCreateDataCreatorService(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Student DBCreateStudent(StudentCreateParams studentCreateParams)
        {
            Student student = new Student()
            {
                FirstName = studentCreateParams.StudentFirstName,
                LastName = studentCreateParams.StudentLastName,
                WLCId = studentCreateParams.StudentWLCId
            };
            _dbContext.students.Add(student);
            _dbContext.SaveChanges();

            return student;
        }
    }
}
