using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentCreateService : IStudentCreateService
    {
        private readonly MathTestDbContext _dbContext;

        public StudentCreateService(MathTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public StudentCreateView CreateStudent(StudentCreateParams studentCreateParams)
        {
            Student student = new Student()
            {
                FirstName = studentCreateParams.StudentFirstName,
                LastName = studentCreateParams.StudentLastName,
                WLCId = studentCreateParams.StudentWLCId
            };
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            var id = student.StudentId;

            StudentCreateView ret = new StudentCreateView
            {
                StudentId = id,
                ResultMessage = "Student created sucessfully"
            };
            return ret;
        }

    }
}
