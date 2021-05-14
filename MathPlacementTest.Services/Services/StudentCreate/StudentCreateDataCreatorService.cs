using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
            // Test if student was previously created within 6 months
            DateTime timeLimit = DateTime.Today.AddMonths(-6);      //change this to change the time limit

            var checkStudentList = _dbContext.Students.Where(st => st.WLCId == studentCreateParams.StudentWLCId).OrderByDescending(st => st.InsertedOn);
            var checkStudent = checkStudentList.FirstOrDefault();
            if (checkStudent != null)
            {
                var TinsertedOn = DateTime.Now - checkStudent.InsertedOn;
                var TtimeLimit = DateTime.Now - timeLimit;
                if (TinsertedOn < TtimeLimit)  //this subtraction creates a datatype we can compare using boolean operators
                {
                    Student errorStudent = new Student()
                    {
                        FirstName = studentCreateParams.StudentFirstName,
                        LastName = studentCreateParams.StudentLastName,
                        WLCId = -1,
                        InsertedOn = DateTime.Now
                    };
                    return errorStudent;
                }
            }

            Student student = new Student()
            {
                FirstName = studentCreateParams.StudentFirstName,
                LastName = studentCreateParams.StudentLastName,
                WLCId = studentCreateParams.StudentWLCId,
                InsertedOn = DateTime.Now
            };
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            return student;
        }
    }
}
