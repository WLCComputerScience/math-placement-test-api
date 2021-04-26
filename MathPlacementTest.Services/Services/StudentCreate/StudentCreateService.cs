using MathPlacementTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlacementTest.Services
{
    public class StudentCreateService : IStudentCreateService
    {
        private readonly IStudentCreateDataCreatorService _studentCreateDataCreator;
        
         public StudentCreateService(IStudentCreateDataCreatorService studentCreateDataCreatorService)
        {
            _studentCreateDataCreator = studentCreateDataCreatorService;
        }

        public StudentCreateView CreateStudent(StudentCreateParams studentCreateParams)
        {
            // Tests
            if (studentCreateParams.StudentWLCId == 0)
            {
                StudentCreateView err = new StudentCreateView
                {
                    StudentId = -1,
                    ResultMessage = "Student ID is 0"
                };
                return err;
            }
            if (studentCreateParams.StudentWLCId < 1)
            {
                StudentCreateView err = new StudentCreateView
                {
                    StudentId = -1,
                    ResultMessage = "Student ID is negative"
                };
                return err;
            }
            if (string.IsNullOrEmpty(studentCreateParams.StudentFirstName))
            {
                StudentCreateView err = new StudentCreateView
                {
                    StudentId = -1,
                    ResultMessage = "Student first name is null or empty"
                };
            return err;
            }
            if (string.IsNullOrEmpty(studentCreateParams.StudentLastName)) {
                StudentCreateView err = new StudentCreateView
                {
                    StudentId = -1,
                    ResultMessage = "Student last name is null or empty"
                };
                return err;
            }
            

            Student student = _studentCreateDataCreator.DBCreateStudent(studentCreateParams);
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
